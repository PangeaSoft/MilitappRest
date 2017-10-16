using MilitappRest.Entities;
using MilitappRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Repositories
{
    public class ListaCandidatoCargoRepository: IRepository<tblistacandidatocargo>
    {
        private static ListaCandidatoCargoRepository listaCandidatoCargoRepository = null;
        private MilitappBDConnection cnx;
        public static ListaCandidatoCargoRepository GetInstancia()
        {
            if (listaCandidatoCargoRepository == null)
                return new ListaCandidatoCargoRepository();
            return listaCandidatoCargoRepository;
        }

        public ListaCandidatoCargoRepository()
        {
            cnx = new MilitappBDConnection();
        }

        public void Create(tblistacandidatocargo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tblistacandidatocargo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblistacandidatocargo entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tblistacandidatocargo entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public object GetList(Func<tblistacandidatocargo, bool> funcion)
        {
            return cnx.tblistacandidatocargo.Where(funcion).ToList();
        }
    }
}
