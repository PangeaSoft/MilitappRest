using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class ListaBusiness
    {
        private ListaRepository listaRepository;

        public ListaBusiness()
        {
            listaRepository = ListaRepository.GetInstancia();
        }

        public object GetElement(tblista entity)
        {
            return listaRepository.GetElement(entity);
        }
    }
}
