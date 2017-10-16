using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class MesaRepository : IRepository<tbmesa>
    {
        private static MesaRepository mesaRepository = null;
        private MilitappBDConnection cnx;

        public static MesaRepository GetInstancia()
        {
            if (mesaRepository == null)
                return new MesaRepository();
            return mesaRepository;
        }

        public MesaRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tbmesa entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbmesa entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbmesa entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbmesa entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }


        public object GetList(Func<tbmesa, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
