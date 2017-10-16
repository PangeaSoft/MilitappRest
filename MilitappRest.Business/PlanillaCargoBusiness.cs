using MilitappRest.Entities;
using MilitappRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Business
{
    public class PlanillaCargoBusiness
    {
        PlanillaCargoRepository planillaCargoRepository;
        
        public PlanillaCargoBusiness()
        {
            planillaCargoRepository = PlanillaCargoRepository.GetInstancia();
        }

        public int ObtenerTotalVotosCargo(int cargoId)
        {
            try
            {
                Func<tbplanillacargo, bool> funcion = x => x.car_id == cargoId;
                List<tbplanillacargo> listaPlanillaCargo = this.GetList(funcion) as List<tbplanillacargo>;

                int totalVotos = listaPlanillaCargo.Sum(x => x.pca_cantidad_votos);

                return totalVotos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(tbplanillacargo entity)
        {
            planillaCargoRepository.Create(entity);
        }

        public object GetList(Func<tbplanillacargo, bool> funcion)
        {
            return planillaCargoRepository.GetList(funcion);
        }
    }
}
