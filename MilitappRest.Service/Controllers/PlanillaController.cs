using MilitappRest.Business;
using MilitappRest.Entities;
using MilitappRest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MilitappRest.Service.Controllers
{
    public class PlanillaController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage EnviarPlanilla(PlanillaModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                //Se almacena la cantidad de sobres
                PlanillaBusiness planillaBusiness = new PlanillaBusiness();
                planillaBusiness.CargarCantidadSobresElectores(model.Planilla);

                //Se cargan los resultados de los candidatos
                ResultadoBusiness resultadoBusiness = new ResultadoBusiness();
                resultadoBusiness.CargarResultado(model.Resultados);

                //Se cargan los totales de votos por candidato
                PlanillaCargoBusiness planillaCargoBusiness = new PlanillaCargoBusiness();
                foreach (var obj in model.PlanillaCargo)
                    planillaCargoBusiness.Create(obj);
            }
            catch (Exception ex)
            {
                responseModel.CodigoRespuesta = -1;
                responseModel.DescripcionRespuesta = "[ERROR]: El registro ya se ingreso.";
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return Request.CreateResponse(HttpStatusCode.OK, responseModel);
            }
            responseModel.DescripcionRespuesta = "El registro se ingreso correctamente.";
            return Request.CreateResponse(HttpStatusCode.OK, responseModel);
        }

        [HttpPut]
        public HttpResponseMessage AbrirPlanilla(tbplanilla entity)
        {
            try
            {
                PlanillaBusiness biz = new PlanillaBusiness();
                biz.AbrirPlanilla(entity);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage CerrarPlanilla(tbplanilla entity)
        {
            try
            {
                PlanillaBusiness biz = new PlanillaBusiness();
                biz.CerrarPlanilla(entity);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public tbplanilla ObtenerPlanilla(int id)
        {
            tbplanilla planilla = new tbplanilla() { pla_id = id };
            PlanillaBusiness biz = new PlanillaBusiness();

            return biz.GetElement(planilla) as tbplanilla;
        }
    }
}
