using Entity.Dto.Parameter;
using Entity.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Business.Interfaces.Operational
{
    public interface IFarmBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<FarmDto> GetById(int id);
        Task<Farm> Save(FarmDto entity);
        Task Update(FarmDto entity);
        Farm mapearDatos(Farm farm, FarmDto entity);
        Task<IEnumerable<FarmDto>> GetAll();
    }
}
