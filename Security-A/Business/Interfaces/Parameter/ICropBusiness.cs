using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Interfaces.Parameter
{
    public interface ICropBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<CropDto> GetById(int id);
        Task<Crop> Save(CropDto entity);
        Task Update(CropDto entity);
        Crop mapearDatos(Crop crop, CropDto entity);
        Task<IEnumerable<CropDto>> GetAll();
    }
}
