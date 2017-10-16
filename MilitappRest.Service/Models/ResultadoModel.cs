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
        public Dictionary<int, double> PorcentajeResultadoDiputados { get; set; }
        public Dictionary<int, double> PorcentajeResultadoLegisladores { get; set; }
        public Dictionary<int, int> CantidadVotosDiputados { get; set; }
        public Dictionary<int, int> CantidadVotosLegisladores { get; set; }
        public List<tbplanilla> ListaPlanillas { get; set; }

        public ResultadoModel()
        {
            PorcentajeResultadoDiputados = new Dictionary<int, double>();
            PorcentajeResultadoLegisladores = new Dictionary<int, double>();
            CantidadVotosDiputados = new Dictionary<int, int>();
            CantidadVotosLegisladores = new Dictionary<int, int>();
            ListaPlanillas = new List<tbplanilla>();
        }
    }
}