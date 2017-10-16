using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class EscuelaBusiness
    {
        private EscuelaRepository escuelaRepository;
        public EscuelaBusiness()
        {
            escuelaRepository = EscuelaRepository.GetInstancia();
        }

        public object GetList()
        {
            return escuelaRepository.GetList();
        }

        public object GetElement(tbescuela entity)
        {
            return escuelaRepository.GetElement(entity);
        }
    }
}
