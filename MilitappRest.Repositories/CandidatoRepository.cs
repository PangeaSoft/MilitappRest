using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class CandidatoRepository : IRepository<tbcandidato>
    {
        private static CandidatoRepository candidatoRepository = null;
        private MilitappBDConnection conn;
        public static CandidatoRepository GetInstancia()
        {
            if (candidatoRepository == null)
                return new CandidatoRepository();

            return candidatoRepository;
        }

        public CandidatoRepository()
        {
            conn = new MilitappBDConnection();
        }

        public void Create(tbcandidato entity)
        {
            try
            {
                conn.tbcandidato.Add(entity);
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbcandidato entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbcandidato entity)
        {
            try
            {
                var obj = (tbcandidato)this.GetElement(entity);
                conn.tbcandidato.Remove(obj);
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbcandidato entity)
        {
            try
            {
                var salida = (tbcandidato)conn.tbcandidato
                    .Where(x => x.can_id == entity.can_id)
                    .FirstOrDefault();

                return salida;
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
                var salida = (List<tbcandidato>)conn.tbcandidato.ToList();
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList(Func<tbcandidato, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
