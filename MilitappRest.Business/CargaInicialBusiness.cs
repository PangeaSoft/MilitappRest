using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class CargaInicialBusiness
    {
        private CargaInicialRepository cargaInicialRepository;
        public CargaInicialBusiness()
        {
            cargaInicialRepository = new CargaInicialRepository();
        }

        public void EjecutarInserts()
        {
            //PRIMERO EJECUTAR LOS INSERTS SQL!!!!!!!//

            //Inserts numeros de mesa: Ejecuto OK
            cargaInicialRepository.InsertNumerosMesa();

            //Inserts planillas: ejecuto OK
            cargaInicialRepository.InsertPlanillas();

            //ULTIMO INSERT candidato-lista
            cargaInicialRepository.InsertListaCandidatoCargo();
        }
    }
}
