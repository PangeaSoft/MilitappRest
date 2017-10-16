using MilitappRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitappRest.Service.Models
{
    [Serializable]
    public class PlanillaModel
    {
        public tbplanilla Planilla { get; set; }
        public List<tbresultado> Resultados { get; set; }
        public List<tbplanillacargo> PlanillaCargo { get; set; }
    
        public PlanillaModel()
        {
            this.Planilla = new tbplanilla();
            this.Resultados = new List<tbresultado>();
            this.PlanillaCargo = new List<tbplanillacargo>();
        }
    }
}