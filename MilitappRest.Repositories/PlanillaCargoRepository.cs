using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class PlanillaCargoRepository : IRepository<tbplanillacargo>
    {
        private static PlanillaCargoRepository instancia = null;
        private MilitappBDConnection cnx = null;

        public static PlanillaCargoRepository GetInstancia()
        {
            if (instancia == null)
                return new PlanillaCargoRepository();
            return instancia;
        }

        public PlanillaCargoRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tbplanillacargo entity)
        {
            try
            {
                cnx.tbplanillacargo.Add(entity);
                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbplanillacargo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbplanillacargo entity)
        {
            try
            {
                List<tbplanillacargo> removeElements = 
                    cnx.tbplanillacargo.Where(x => x.pla_id == entity.pla_id).ToList();
                foreach (var obj in removeElements)
                    cnx.tbplanillacargo.Remove(obj);

                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbplanillacargo entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public object GetList(Func<tbplanillacargo, bool> funcion)
        {
            try
            {
                return cnx.tbplanillacargo.Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
