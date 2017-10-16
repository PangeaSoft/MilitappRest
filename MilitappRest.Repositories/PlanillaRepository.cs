using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class PlanillaRepository : IRepository<tbplanilla>
    {
        private static PlanillaRepository instancia = null;
        private MilitappBDConnection cnx = null;
        public static PlanillaRepository GetInstancia()
        {
            if (instancia == null)
                return new PlanillaRepository();
            return instancia;
        }

        public PlanillaRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tbplanilla entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbplanilla entity)
        {
            try
            {
                cnx.tbplanilla.Attach(entity);
                var entry = cnx.Entry(entity);
                entry.State = System.Data.EntityState.Modified;
                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbplanilla entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbplanilla entity)
        {
            try
            {
                return cnx.tbplanilla.Find(entity.pla_id);
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
                return cnx.tbplanilla.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList(Func<tbplanilla, bool> funcion)
        {
            try
            {
                return cnx.tbplanilla.Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
