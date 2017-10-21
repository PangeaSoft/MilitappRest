using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class ComunaBusiness
    {
        ComunaRepository comunaRepository = null;
        public ComunaBusiness()
        {
            comunaRepository = ComunaRepository.GetInstancia();
        }

        public object ObtenerEscuelasPorComuna()
        {
            List<tbcomuna> listaComunas = new List<tbcomuna>();

            PlanillaBusiness bizPlanilla = new PlanillaBusiness();
            Func<tbplanilla, bool> funcion = x => x.pla_sobres > 0;
            List<tbplanilla> planillas = bizPlanilla.GetList(funcion) as List<tbplanilla>;

            return listaComunas;
        }

        //FORMA CORRECTA, NO DESCARTAR
        public object ObtenerEscuelasPorComunaOLD()
        {
            //Traigo todas las comunas 
            ComunaBusiness comunaBusiness = new ComunaBusiness();
            List<tbcomuna> listaComunas = new List<tbcomuna>();
            listaComunas = comunaBusiness.GetList() as List<tbcomuna>;

            //Obtengo las planillas cargadas
            PlanillaBusiness planillaBusiness = new PlanillaBusiness();
            Func<tbplanilla, bool> funcion = x => x.pla_sobres > 0;
            List<tbplanilla> listaPlanillas = planillaBusiness.GetList(funcion) as List<tbplanilla>;

            //Cargo las escuelas correspondientes a cada planilla
            List<tbescuela> listaEscuelas = new List<tbescuela>();
            EscuelaBusiness escuelaBusiness = new EscuelaBusiness();

            foreach (var planilla in listaPlanillas)
            {
                planilla.tbescuela = new tbescuela();
                planilla.tbescuela = escuelaBusiness.GetElement(new tbescuela() { esc_id = planilla.esc_id }) as tbescuela;
            }

            //Cargo a las comunas sus planillas correspondientes
            foreach (var p in listaPlanillas)
            {

            }

            return listaPlanillas;
        }

        #region CRUD Methods
        public void Create(tbcomuna entity)
        {
            comunaRepository.Create(entity);
        }

        public void Update(tbcomuna entity)
        {
            comunaRepository.Update(entity);
        }

        public void Delete(tbcomuna entity)
        {
            comunaRepository.Delete(entity);
        }

        public object GetElement(tbcomuna entity)
        {
            return comunaRepository.GetElement(entity);
        }

        public object GetList()
        {
            return comunaRepository.GetList();
        }
        #endregion
    }
}
