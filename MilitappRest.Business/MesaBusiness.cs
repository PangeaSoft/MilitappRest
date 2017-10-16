using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class MesaBusiness
    {
        MesaRepository mesaRepository = null;
        public MesaBusiness()
        {
            mesaRepository = MesaRepository.GetInstancia();
        }

    }
}
