using MilitappRest.Business;
using MilitappRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MilitappRest.Service.Controllers
{
    public class CandidatoController : ApiController
    {
        [HttpPost]
        public bool Create(tbcandidato candidato)
        {
            //FUNCIONANDO OK
            CandidatoBusiness biz = new CandidatoBusiness();
            biz.Create(candidato);

            return true;
        }

        [HttpPut]
        public bool Update(tbcandidato candidato)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public bool Delete(tbcandidato candidato)
        {
            CandidatoBusiness biz = new CandidatoBusiness();
            biz.Delete(candidato);
            return true;
        }

        [HttpGet]
        public tbcandidato GetElement(int id)
        {
            CandidatoBusiness biz = new CandidatoBusiness();
            return biz.GetElement(new tbcandidato() { can_id = id }) as tbcandidato;
        }

        [HttpGet]
        public List<tbcandidato> GetList()
        {
            CandidatoBusiness biz = new CandidatoBusiness();
            return biz.GetList() as List<tbcandidato>;
        }

    }
}
