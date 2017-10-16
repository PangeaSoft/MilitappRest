using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class ListaCandidatoCargoBusiness
    {
        ListaCandidatoCargoRepository listaCandidatoCargoRepository = null;
        public ListaCandidatoCargoBusiness()
        {
            listaCandidatoCargoRepository = ListaCandidatoCargoRepository.GetInstancia();
        }

        public object GetList(Func<tblistacandidatocargo, bool> funcion)
        {
            return listaCandidatoCargoRepository.GetList(funcion);
        }
    }
}
