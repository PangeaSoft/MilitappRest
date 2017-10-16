using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class CandidatoBusiness
    {
        private CandidatoRepository repository = null;
        public CandidatoBusiness()
        {
            repository = CandidatoRepository.GetInstancia();
        }

        public void Create(tbcandidato candidato)
        {
            repository.Create(candidato);
        }

        public void Update(tbcandidato candidato)
        {
        }

        public void Delete(tbcandidato candidato)
        {
            repository.Delete(candidato);
        }

        public object GetElement(tbcandidato candidato)
        {
            return repository.GetElement(candidato);
        }

        public object GetList()
        {
            return repository.GetList();
        }
    }
}
