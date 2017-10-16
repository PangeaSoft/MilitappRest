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
    public class ComunaController : ApiController
    {
        [HttpPost]
        public void Create(tbcomuna comuna)
        {
            ComunaBusiness biz = new ComunaBusiness();
            biz.Create(comuna);
        }

        [HttpPut]
        public void Update(tbcomuna entity)
        {
            ComunaBusiness biz = new ComunaBusiness();
            biz.Update(entity);
        }

        [HttpDelete]
        public void Delete(tbcomuna entity)
        {
            ComunaBusiness biz = new ComunaBusiness();
            biz.Delete(entity);
        }

        [HttpGet]
        public tbcomuna GetElement(int id)
        {
            tbcomuna comuna = new tbcomuna() { com_id = id };
            ComunaBusiness biz = new ComunaBusiness();
            return biz.GetElement(comuna) as tbcomuna;
        }

        [HttpGet]
        public List<tbcomuna> GetList()
        {
            ComunaBusiness biz = new ComunaBusiness();
            var salida = biz.GetList() as List<tbcomuna>;
            return salida;
        }

        [HttpGet]
        public HttpResponseMessage ObtenerPlanillasPorComuna()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
