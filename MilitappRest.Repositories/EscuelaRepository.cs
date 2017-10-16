using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class EscuelaRepository : IRepository<tbescuela>
    {
        private static EscuelaRepository instancia = null;
        private MilitappBDConnection cnx = null;

        public static EscuelaRepository GetInstancia()
        {
            if (instancia == null)
                return new EscuelaRepository();
            return instancia;
        }

        public EscuelaRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tbescuela entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbescuela entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbescuela entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbescuela entity)
        {
            try
            {
                return cnx.tbescuela.Where(x => x.esc_id == entity.esc_id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            try
            {
                return cnx.tbescuela.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList(Func<tbescuela, bool> funcion)
        {
            try
            {
                return cnx.tbescuela.Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
