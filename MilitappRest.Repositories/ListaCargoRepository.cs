using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class ListaCargoRepository : IRepository<tblistacargo>
    {
        private static ListaCargoRepository listaCargoRepository;
        private MilitappBDConnection cnx = null;

        public static ListaCargoRepository GetInstancia()
        {
            if (listaCargoRepository == null)
                return new ListaCargoRepository();
            return listaCargoRepository;
        }

        public ListaCargoRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tblistacargo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tblistacargo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblistacargo entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tblistacargo entity)
        {
            try
            {
                return cnx.tblistacargo.Where(x => x.lca_id == entity.lca_id).FirstOrDefault();
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

        public object GetList(Func<tblistacargo, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
