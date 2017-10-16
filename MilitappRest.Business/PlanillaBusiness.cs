using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class PlanillaBusiness
    {
        private PlanillaRepository planillaRepository;
        public PlanillaBusiness()
        {
            planillaRepository = PlanillaRepository.GetInstancia();
        }

        public void AbrirPlanilla(tbplanilla planilla)
        {
            var original = this.GetElement(planilla) as tbplanilla;
            if (original.pla_apertura != null)
                throw new Exception("Error: La planilla ya esta abierta.");

            if (planilla.pla_apertura == null)
                throw new Exception("Error: El formato de fecha es incorrecto.");

            original.pla_apertura = planilla.pla_apertura;
            this.Update(original);
        }

        public void CerrarPlanilla(tbplanilla planilla)
        {
            var original = this.GetElement(planilla) as tbplanilla;
            
            if (original.pla_cierre != null)
                throw new Exception("Error: La planilla ya esta cerrada.");

            if (planilla.pla_cierre == null)
                throw new Exception("Error: El formato de fecha es incorrecto.");

            original.pla_cierre = planilla.pla_cierre;
            this.Update(original);
        }

        public void CargarCantidadSobresElectores(tbplanilla planilla)
        {
            var original = this.GetElement(planilla)as tbplanilla;
            if (original.pla_sobres > 0)
                throw new Exception("Error: La cantidad de sobres y electores ya fue ingresada.");
            original.pla_electores = planilla.pla_electores;
            original.pla_sobres = planilla.pla_sobres;
            this.Update(original);
        }

        public int? ObtenerCantidadSobres()
        {
            var planillas = this.GetList() as List<tbplanilla>;
            return planillas.Sum(x => x.pla_sobres);
        }

        public object ObtenerPlanillas()
        {
            Func<tbplanilla, bool> funcion = x => x.pla_sobres > 0;
            var planillas = this.GetList(funcion) as List<tbplanilla>;

            ResultadoBusiness resultadoBusiness = new ResultadoBusiness();
            PlanillaCargoBusiness planillaCargoBusiness = new PlanillaCargoBusiness();
            foreach (var p in planillas)
            {
                //Cargo Resultados a la planilla
                Func<tbresultado, bool> funcionPlanilla = x => x.pla_id == p.pla_id;
                p.tbresultado = new List<tbresultado>();
                p.tbresultado = resultadoBusiness.GetList(funcionPlanilla) as List<tbresultado>;

                //Cargo los resultados segun el cargo
                Func<tbplanillacargo, bool> funcionPlanillaCargo = x => x.pla_id == p.pla_id;
                p.tbplanillacargo = new List<tbplanillacargo>();
                p.tbplanillacargo = planillaCargoBusiness.GetList(funcionPlanillaCargo) as List<tbplanillacargo>;
            }
    
            return planillas;
        }
        
        public void Update(tbplanilla entity)
        {
            planillaRepository.Update(entity);
        }

        public object GetElement(tbplanilla entity)
        {
            return planillaRepository.GetElement(entity);
        }

        public object GetList()
        {
            try
            {
                return planillaRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList(Func<tbplanilla, bool> funcion)
        {
            try
            {
                return planillaRepository.GetList(funcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
