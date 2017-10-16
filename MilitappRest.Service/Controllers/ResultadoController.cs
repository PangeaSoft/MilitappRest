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
    public class ResultadoController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ObtenerResultadosParciales()
        {
            ResultadoModel model = new ResultadoModel();
            try
            {
                //Modificar cuando las planillas no coincidan con el numero de mesa, por ahora se deja así
                PlanillaCargoBusiness planillaCargoBusiness = new PlanillaCargoBusiness();
                int cantidadVotosDiputados = planillaCargoBusiness.ObtenerTotalVotosCargo(1);
                int cantidadVotosLegisladores = planillaCargoBusiness.ObtenerTotalVotosCargo(2);

                //Codigos de diputados
                int[] idsDiputados = new int[4] { 1, 3, 5, 7 };
                //Codigos de diputados
                int[] idsLegisladores = new int[4] { 2, 4, 6, 8 };

                ResultadoBusiness biz = new ResultadoBusiness();
                model.CantidadVotosDiputados = biz.ObtenerVotosPorLista(cantidadVotosDiputados, idsDiputados);
                model.CantidadVotosLegisladores = biz.ObtenerVotosPorLista(cantidadVotosLegisladores, idsLegisladores);

                model.PorcentajeResultadoDiputados = biz.ObtenerPorcentajesPorLista(cantidadVotosDiputados, model.CantidadVotosDiputados);
                model.PorcentajeResultadoLegisladores = biz.ObtenerPorcentajesPorLista(cantidadVotosLegisladores, model.CantidadVotosLegisladores);

                //Cargo planilla
                PlanillaBusiness bizPlanillas = new PlanillaBusiness();
                model.ListaPlanillas = bizPlanillas.ObtenerPlanillas() as List<tbplanilla>;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpGet]
        public HttpResponseMessage ObtenerDiputadosGanadores()
        {
            List<tblistacandidatocargo> listaSalida = new List<tblistacandidatocargo>();
            try
            {
                //Codigos de diputados
                int[] idsDiputados = new int[4] { 1, 3, 5, 7 };

                ResultadoBusiness biz = new ResultadoBusiness();
                listaSalida = biz.ObtenerDiputadosGanadores(idsDiputados) as List<tblistacandidatocargo>;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listaSalida);
        }

        [HttpGet]
        public HttpResponseMessage ObtenerLegisladoresGanadores()
        {
            List<tblistacandidatocargo> listaSalida = new List<tblistacandidatocargo>();
            try
            {
                //Codigos de diputados
                int[] idsLegisladores = new int[4] { 2, 4, 6, 8 };

                ResultadoBusiness biz = new ResultadoBusiness();
                listaSalida = biz.ObtenerLegisladoresGanadores(idsLegisladores) as List<tblistacandidatocargo>;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listaSalida);
        }
    }
}
