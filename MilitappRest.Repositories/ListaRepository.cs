using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class ListaRepository : IRepository<tblista>
    {
        private static ListaRepository listaRepository;
        private MilitappBDConnection cnx = null;

        public static ListaRepository GetInstancia()
        {
            if (listaRepository == null)
                return new ListaRepository();
            return listaRepository;
        }

        public ListaRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tblista entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tblista entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblista entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tblista entity)
        {
            try
            {
                return cnx.tblista.Where(x => x.lis_id == entity.lis_id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public object GetList(Func<tblista, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
