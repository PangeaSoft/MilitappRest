using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class ComunaRepository : IRepository<tbcomuna>
    {
        private static ComunaRepository instancia = null;
        private MilitappBDConnection cnx;
        public static ComunaRepository GetInstancia()
        {
            if (instancia == null)
                return new ComunaRepository();
            return instancia;
        }

        public ComunaRepository()
        {
            cnx = new MilitappBDConnection();
            cnx.Configuration.ProxyCreationEnabled = false;
        }

        public void Create(tbcomuna entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbcomuna entity)
        {
            try
            {
                cnx.tbcomuna.Attach(entity);
                var entry = cnx.Entry(entity);
                entry.State = System.Data.EntityState.Modified;
                //entry.Property(x => x.com_descripcion).IsModified = false;

                cnx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbcomuna entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbcomuna entity)
        {
            return cnx.tbcomuna.Where(x => x.com_id == entity.com_id).FirstOrDefault();
        }

        public object GetList()
        {
            return cnx.tbcomuna.ToList<tbcomuna>();
        }


        public object GetList(Func<tbcomuna, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
