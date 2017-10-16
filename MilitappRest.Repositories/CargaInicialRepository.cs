using MilitappRest.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class CargaInicialRepository
    {
        private MilitappBDConnection cnx = new MilitappBDConnection();

        #region Metodos utilizados unicamente para la carga inicial.
        //FUNCIONO OK
        public void InsertNumerosMesa()
        {
            try
            {
                tbmesa mesa;
                for (int i = 1; i <= 7386; i++)
                {
                    mesa = new tbmesa() { mes_id = i, mes_numero = i };
                    cnx.tbmesa.Add(mesa);
                }
                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertPlanillas()
        {
            int[] arregloMesas = new int[] { 11, 10, 10, 8, 9, 6, 6, 7, 7, 14, 9, 18, 16, 12, 6, 14, 4, 17, 9, 13, 9, 11, 12, 11,
                11, 8, 10, 9, 9, 15, 10, 8, 4, 8, 6, 5, 13, 4, 11, 7, 10, 8, 5, 3, 11, 5, 9, 5, 13, 8, 4, 8, 4, 6, 10, 10, 3, 10,
                24, 5, 6, 22, 6, 10, 3, 18, 11, 5, 13, 10, 6, 4, 11, 14, 13, 14, 8, 4, 7, 20, 10, 13, 5, 9, 15, 7, 11, 26, 9, 6,
                16, 21, 13, 10, 8, 4, 13, 8, 6, 6, 16, 16, 6, 10, 8, 6, 5, 4, 5, 14, 10, 12, 8, 14, 8, 10, 10, 10, 7, 13, 12, 5,
                4, 4, 8, 11, 10, 10, 10, 7, 4, 7, 7, 13, 8, 10, 8, 5, 4, 7, 7, 8, 9, 6, 15, 9, 6, 8, 11, 12, 14, 13, 8, 10, 7, 10,
                8, 5, 8, 7, 6, 6, 14, 14, 8, 6, 5, 9, 5, 6, 4, 5, 8, 8, 7, 8, 13, 14, 11, 11, 5, 14, 16, 8, 8, 9, 9, 9, 11, 4, 10,
                8, 5, 15, 9, 7, 7, 5, 6, 5, 6, 6, 7, 6, 4, 9, 13, 11, 9, 6, 8, 7, 6, 20, 16, 11, 9, 10, 8, 16, 13, 12, 4, 7, 10, 5,
                22, 8, 11, 11, 22, 18, 6, 13, 20, 19, 6, 7, 12, 14, 12, 5, 9, 9, 11, 10, 9, 16, 13, 9, 8, 8, 6, 16, 10, 7, 5, 4, 6,
                4, 6, 12, 7, 11, 11, 14, 12, 6, 11, 6, 11, 7, 4, 23, 24, 25, 15, 14, 13, 11, 11, 11, 16, 7, 5, 11, 13, 9, 6, 4, 7,
                15, 14, 8, 7, 15, 6, 4, 11, 8, 11, 6, 12, 5, 16, 8, 12, 7, 6, 7, 7, 9, 3, 10, 9, 20, 3, 14, 4, 9, 7, 12, 10, 13, 9,
                4, 10, 13, 11, 9, 10, 2, 7, 3, 17, 5, 14, 3, 10, 11, 8, 10, 4, 3, 13, 7, 2, 16, 8, 13, 13, 9, 10, 12, 7, 9, 10, 7,
                11, 10, 10, 11, 11, 9, 13, 7, 9, 9, 13, 15, 13, 13, 16, 11, 10, 13, 10, 12, 9, 17, 15, 7, 9, 14, 15, 10, 10, 17,
                10, 8, 7, 11, 8, 7, 7, 12, 13, 7, 17, 13, 9, 6, 4, 15, 10, 7, 8, 5, 5, 7, 9, 5, 7, 7, 9, 9, 4, 5, 8, 6, 10, 10, 17,
                5, 16, 9, 8, 7, 8, 7, 5, 8, 8, 6, 6, 7, 7, 7, 5, 5, 8, 6, 5, 11, 10, 6, 6, 5, 11, 12, 14, 12, 12, 6, 6, 10, 11, 7,
                7, 10, 3, 6, 13, 5, 9, 6, 7, 6, 7, 5, 5, 4, 9, 12, 7, 7, 6, 3, 5, 7, 12, 11, 11, 10, 7, 5, 9, 7, 4, 6, 4, 6, 6, 10,
                13, 5, 10, 10, 12, 7, 4, 4, 10, 12, 7, 3, 7, 12, 8, 12, 4, 13, 7, 9, 7, 6, 7, 10, 12, 11, 7, 7, 7, 6, 8, 7, 7, 10,
                7, 6, 6, 6, 12, 11, 5, 8, 3, 8, 2, 3, 8, 2, 10, 6, 9, 7, 5, 8, 10, 12, 7, 5, 4, 7, 9, 9, 10, 12, 6, 10, 6, 5, 6, 3,
                6, 6, 12, 9, 4, 6, 11, 8, 9, 9, 5, 11, 7, 6, 7, 6, 5, 8, 9, 7, 7, 4, 6, 11, 7, 8, 6, 7, 8, 8, 6, 5, 3, 9, 7, 11, 7,
                4, 6, 12, 10, 13, 6, 6, 6, 7, 4, 5, 5, 4, 7, 13, 10, 16, 8, 5, 9, 8, 14, 13, 10, 5, 5, 7, 5, 12, 10, 8, 6, 8, 7, 8,
                3, 23, 8, 8, 6, 12, 17, 14, 8, 3, 19, 15, 6, 15, 5, 16, 15, 10, 4, 10, 8, 12, 11, 30, 6, 14, 5, 15, 9, 12, 6, 20,
                13, 14, 10, 6, 8, 16, 6, 12, 9, 6, 4, 6, 3, 9, 6, 13, 8, 10, 7, 6, 15, 5, 14, 9, 12, 3, 10, 14, 12, 12, 9, 9, 10,
                6, 9, 10, 5, 15, 16, 6, 20, 12, 10, 17, 6, 5, 40, 10, 7, 13, 6, 14, 4, 8, 10, 15, 8, 5, 20, 15, 12, 3, 15, 14, 15,
                10, 8, 10, 6, 5, 11, 12, 8, 10, 11, 5, 6, 5, 12, 11, 6, 6, 7, 17, 8, 13, 9, 19, 13, 14, 7, 5, 6, 8, 6, 3, 12, 2, 
                18, 8, 7, 5, 8, 6, 7, 5, 2, 8, 18, 7, 16, 5, 5, 10, 4, 7, 8, 10, 10, 6, 16, 5, 9, 7, 6, 13, 9, 4, 9, 8, 7, 6, 7, 
                5, 4, 7, 4, 7, 11, 14, 11, 7, 9, 9, 7, 6 };

            int contadorMesa = 0;
            int numeroEscuela = 1;
            tbplanilla planilla;
            DateTime fecha = DateTime.ParseExact("22/10/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            foreach (int cantMesas in arregloMesas)
            {
                for (int i = 1; i <= cantMesas; i++)
                {
                    contadorMesa++;
                    planilla = new tbplanilla()
                    {
                        ele_fecha = fecha,
                        mes_id = contadorMesa,
                        esc_id = numeroEscuela,
                        fis_id = 1,
                        pla_apertura = null,
                        pla_cierre = null,
                        pla_sobres = 0
                    };
                    cnx.tbplanilla.Add(planilla);
                }
                numeroEscuela++;
            }

            cnx.SaveChanges();
        }

        public void InsertListaCandidatoCargo()
        {
            tblistacandidatocargo lcc = null;
            int ordenDiputado = 1;
            int ordenSenador = 1;

            for (int idCandidato = 1; idCandidato <= 172; idCandidato++)
            {
                //VAMOS JUNTOS
                if (idCandidato <= 13)
                {
                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 1,
                        can_id = idCandidato,
                        lcc_orden = ordenDiputado
                    };
                    ordenDiputado++;
                }
                if (idCandidato >= 14 && idCandidato <= 43)
                {
                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 2,
                        can_id = idCandidato,
                        lcc_orden = ordenSenador
                    };
                    ordenSenador++;
                }

                //UNIDAD PORTEÑA
                if (idCandidato >= 44 && idCandidato <= 56)
                {
                    if (idCandidato == 44)
                    {
                        ordenDiputado = 1;
                        ordenSenador = 1;
                    }

                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 3,
                        can_id = idCandidato,
                        lcc_orden = ordenDiputado
                    };
                    ordenDiputado++;
                }
                if (idCandidato >= 57 && idCandidato <= 86)
                {
                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 4,
                        can_id = idCandidato,
                        lcc_orden = ordenSenador
                    };
                    ordenSenador++;
                }

                //EVOLUCION CIUDADANA
                if (idCandidato >= 87 && idCandidato <= 99)
                {
                    if (idCandidato == 87)
                    {
                        ordenDiputado = 1;
                        ordenSenador = 1;
                    }

                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 5,
                        can_id = idCandidato,
                        lcc_orden = ordenDiputado
                    };
                    ordenDiputado++;
                }
                if (idCandidato >= 100 && idCandidato <= 129)
                {
                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 6,
                        can_id = idCandidato,
                        lcc_orden = ordenSenador
                    };
                    ordenSenador++;
                }

                //1PAIS
                if (idCandidato >= 130 && idCandidato <= 142)
                {
                    if (idCandidato == 130)
                    {
                        ordenDiputado = 1;
                        ordenSenador = 1;
                    }

                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 7,
                        can_id = idCandidato,
                        lcc_orden = ordenDiputado
                    };
                    ordenDiputado++;
                }
                if (idCandidato >= 143 && idCandidato <= 172)
                {
                    lcc = new tblistacandidatocargo()
                    {
                        lca_id = 8,
                        can_id = idCandidato,
                        lcc_orden = ordenSenador
                    };
                    ordenSenador++;
                }
                //Agrego el objeto a la tabla
                cnx.tblistacandidatocargo.Add(lcc);
            }
            //Guardo los cambios
            cnx.SaveChanges();
        }
        #endregion
    }
}
