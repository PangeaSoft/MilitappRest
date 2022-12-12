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
        public HttpResponseMessage EnviarPlanilla2(PlanillaModel model)
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
        public HttpResponseMessage AbrirPlanilla2(tbplanilla entity)
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
        public HttpResponseMessage CerrarPlanilla2(tbplanilla entity)
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

        [HttpPut]
        public HttpResponseMessage EliminarPlanilla(tbplanilla entity)
        {
            try
            {
                //Se reinician valores de la planilla
                PlanillaBusiness biz = new PlanillaBusiness();
                biz.ReiniciarPlanilla(entity);

                //Se eliminan los resultados
                tbresultado resultado = new tbresultado() { pla_id = entity.pla_id };
                ResultadoBusiness bizResultados = new ResultadoBusiness();
                bizResultados.Delete(resultado);

                //Se eliminan planilla cargo con los votos cargados
                tbplanillacargo planillaCargo = new tbplanillacargo() { pla_id = entity.pla_id };
                PlanillaCargoBusiness bizPlanillaCargo = new PlanillaCargoBusiness();
                bizPlanillaCargo.Delete(planillaCargo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage ObtenerPlanillasAbiertasCerradas()
        {
            List<tbplanilla> planillas = new List<tbplanilla>();
            try
            {
                PlanillaBusiness biz = new PlanillaBusiness();
                planillas = biz.ObtenerPlanillasAbiertasCerradas() as List<tbplanilla>;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, planillas);
        }
    }
}
