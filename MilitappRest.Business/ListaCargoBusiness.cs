using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class ListaCargoBusiness
    {
        private ListaCargoRepository listaCargoRepository;

        public ListaCargoBusiness()
        {
            listaCargoRepository = ListaCargoRepository.GetInstancia();
        }

        public object GetElement(tblistacargo entity)
        {
            return listaCargoRepository.GetElement(entity);
        }
    }
}
