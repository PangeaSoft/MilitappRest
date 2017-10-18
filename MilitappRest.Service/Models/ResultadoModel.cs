using MilitappRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitappRest.Service.Models
{
    [Serializable]
    public class ResultadoModel
    {
        public List<tblistacargo> PorcentajeResultadoDiputados { get; set; }
        public List<tblistacargo> PorcentajeResultadoLegisladores { get; set; }
        public List<tblistacargo> CantidadVotosDiputados { get; set; }
        public List<tblistacargo> CantidadVotosLegisladores { get; set; }
        public List<tbplanilla> ListaPlanillas { get; set; }

        public ResultadoModel()
        {
            PorcentajeResultadoDiputados = new List<tblistacargo>();
            PorcentajeResultadoLegisladores = new List<tblistacargo>();
            CantidadVotosDiputados = new List<tblistacargo>();
            CantidadVotosLegisladores = new List<tblistacargo>();
            ListaPlanillas = new List<tbplanilla>();
        }
    }
}