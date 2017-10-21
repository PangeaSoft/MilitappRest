using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class ResultadoRepository : IRepository<tbresultado>
    {
        private static ResultadoRepository resultadoRepository = null;
        private MilitappBDConnection cnx = null;
        
        public static ResultadoRepository GetInstancia()
        {
            if (resultadoRepository == null)
                return new ResultadoRepository();
            return resultadoRepository;
        }

        public ResultadoRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tbresultado entity)
        {
            try
            {
                cnx.tbresultado.Add(entity);
                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbresultado entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbresultado entity)
        {
            try
            {
                List<tbresultado> removeElements =
                    cnx.tbresultado.Where(x => x.pla_id == entity.pla_id).ToList();
                foreach (var obj in removeElements)
                    cnx.tbresultado.Remove(obj);

                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbresultado entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            return cnx.tbresultado.ToList();
        }

        public object GetList(Func<tbresultado, bool> funcion)
        {
            try
            {
                return cnx.tbresultado.Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
