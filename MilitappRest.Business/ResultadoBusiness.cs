using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class ResultadoBusiness
    {
        private ResultadoRepository resultadoRepository;
        private const int CANTIDAD_DIPUTADOS = 13;
        private const int CANTIDAD_LEGISLADORES = 30;

        public ResultadoBusiness()
        {
            resultadoRepository = ResultadoRepository.GetInstancia();
        }

        public void CargarResultado(List<tbresultado> resultados)
        {
            foreach (var obj in resultados)
                resultadoRepository.Create(obj);
        }

        public List<tblistacargo> ObtenerVotosPorLista(int cantidadSobres, int[] idListaCandidatos)
        {
            List<tblistacargo> resultados = new List<tblistacargo>();
            tblistacargo listaCargo = null;
            int votosDominioLista = 0;

            foreach (int codigoListaCandidato in idListaCandidatos)
            {
                int votos = this.ResultadosListaCargo(codigoListaCandidato);
                votosDominioLista += votos;

                listaCargo = new tblistacargo()
                {
                    lca_id = codigoListaCandidato,
                    lca_cantidad_votos = votos
                };

                resultados.Add(listaCargo);
            }
            int diferenciaVotosDominio = cantidadSobres - votosDominioLista;
            resultados.Add(new tblistacargo() 
            { 
                lca_id = 99, 
                lca_cantidad_votos = diferenciaVotosDominio 
            });
            

            return resultados;
        }

        public List<tblistacargo> ObtenerPorcentajesPorLista(int cantidadSobres, List<tblistacargo> cantidadVotosLista)
        {
            List<tblistacargo> resultados = new List<tblistacargo>();
            tblistacargo r = null;

            foreach (var obj in cantidadVotosLista)
            {
                r = new tblistacargo();
                r.lca_id = obj.lca_id;
                r.lca_porcentaje_votos = (double)(obj.lca_cantidad_votos * 100) / cantidadSobres;

                resultados.Add(r);
            }

            return resultados;
        }

        private int ResultadosListaCargo(int listaCargoId)
        {
            Func<tbresultado, bool> whereClausule = p => p.lca_id == listaCargoId;
            var resultadosLista = resultadoRepository.GetList(whereClausule) as List<tbresultado>;

            int votos = resultadosLista.Sum(x => x.res_cantidad_votos);

            return votos;
        }

        #region Calcular Diputados y Legisladores Ingresantes al Congreso
        public List<tblistacandidatocargo> ObtenerDiputadosGanadores(int[] arregloListaCargoId)
        {
            List<tblistacandidatocargo> listaDiputadosGanadores = new List<tblistacandidatocargo>();
            listaDiputadosGanadores =
                this.CargarListasCandidatosConSuPromedio(arregloListaCargoId, CANTIDAD_DIPUTADOS);

            return listaDiputadosGanadores;
        }

        public List<tblistacandidatocargo> ObtenerLegisladoresGanadores(int[] arregloListaCargoId)
        {
            List<tblistacandidatocargo> listaLegisladoresGanadores = new List<tblistacandidatocargo>();
            listaLegisladoresGanadores =
                this.CargarListasCandidatosConSuPromedio(arregloListaCargoId, CANTIDAD_LEGISLADORES);

            return listaLegisladoresGanadores;
        }

        private List<tblistacandidatocargo> CargarListasCandidatosConSuPromedio(int[] arregloListaCargoId, int topGanadores)
        {
            List<tblistacandidatocargo> listaDiputadosGanadores = new List<tblistacandidatocargo>();
            foreach (int listaCargoId in arregloListaCargoId)
            {
                List<tblistacandidatocargo> listaParcial = ObtenerListadoParcialCandidatos(listaCargoId, topGanadores);
                listaDiputadosGanadores.AddRange(listaParcial);
            }

            return listaDiputadosGanadores.OrderByDescending(x => x.lcc_votos_correspondientes)
                .Take(topGanadores)
                .ToList();
        }

        private List<tblistacandidatocargo> ObtenerListadoParcialCandidatos(int listaCargoId, int topGanadores)
        {
            decimal[] arregloVotos = this.ObtenerArregloVotosCandidatos(listaCargoId, topGanadores);
            List<tblistacandidatocargo> listaSalidaOrdenada = this.ObtenerListaCandidatoCargo(listaCargoId);
            int i = 0;

            foreach (var listaCandidatoCargo in listaSalidaOrdenada)
            {
                listaCandidatoCargo.lcc_votos_correspondientes = arregloVotos[i];
                i++;
            }

            return listaSalidaOrdenada;
        }

        private decimal[] ObtenerArregloVotosCandidatos(int listaCargoId, int topGanadores)
        {
            int cantidadVotos = this.ResultadosListaCargo(listaCargoId);
            decimal[] arregloVotos = new decimal[topGanadores];
            int j = 0;

            for (int i = 1; i <= topGanadores; i++)
            {
                arregloVotos[j] = (decimal)cantidadVotos / i;
                j++;
            }

            return arregloVotos;
        }

        private List<tblistacandidatocargo> ObtenerListaCandidatoCargo(int listaCargoId)
        {
            ListaCandidatoCargoBusiness listaCandidatoCargoBusiness = new ListaCandidatoCargoBusiness();
            //Armo la funcion
            Func<tblistacandidatocargo, bool> funcion = x => x.lca_id == listaCargoId;
            //Cargo la lista
            List<tblistacandidatocargo> listaCandidatoCargo = 
                listaCandidatoCargoBusiness.GetList(funcion)as List<tblistacandidatocargo>;

            this.CargoCandidatos(listaCandidatoCargo);
            this.CargoLista(listaCandidatoCargo);

            return listaCandidatoCargo.OrderBy(x => x.lcc_orden).ToList();
        }

        private void CargoLista(List<tblistacandidatocargo> listaCandidatoCargo)
        {
            tblistacandidatocargo obj = listaCandidatoCargo.First();
            
            //Primero obtengo la lista cargo
            ListaCargoBusiness listaCargoBusiness = new ListaCargoBusiness();
            tblistacargo listaCargo = listaCargoBusiness.GetElement(new tblistacargo() { lca_id = obj.lca_id }) as tblistacargo; 

            //Despues puedo obtener la lista con lis_id de listaCargo
            ListaBusiness listaBusiness = new ListaBusiness();
            tblista lista = listaBusiness.GetElement(new tblista() { lis_id = listaCargo.lis_id }) as tblista;

            foreach (var lcc in listaCandidatoCargo)
            {
                //Asigno lista cargo
                lcc.tblistacargo = new tblistacargo();
                lcc.tblistacargo = listaCargo;

                //Asigno lista
                lcc.tblistacargo.tblista = new tblista();
                lcc.tblistacargo.tblista = lista;
            }
        }

        private void CargoCandidatos(List<tblistacandidatocargo> listaCandidatoCargo)
        {
            CandidatoBusiness candidatoBusiness = new CandidatoBusiness();
            
            foreach (var obj in listaCandidatoCargo)
            {
                obj.tbcandidato = new tbcandidato();
                obj.tbcandidato = candidatoBusiness.GetElement(new tbcandidato() { can_id = obj.can_id }) as tbcandidato;
            }
        }
        #endregion

        public object GetList(Func<tbresultado, bool> funcion)
        {
            return resultadoRepository.GetList(funcion);
        }
    }
}
