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
    public class CargaInicialController : ApiController
    {
        [HttpPost]
        public bool Create(tbcandidato candidato)
        {
            //Mesas test inserts iniciales
            CargaInicialBusiness biz = new CargaInicialBusiness();
            //biz.EjecutarInserts();
            return true;
        }

        [HttpGet]
        public HttpResponseMessage ObtenerConexion()
        {
            tbfiscal f = new tbfiscal() { fis_nombre = "Leo" };
            return Request.CreateResponse(HttpStatusCode.OK, f);
        }
    }
}
