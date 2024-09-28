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
    public interface ISuppliesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<SuppliesDto> GetById(int id);
        Task<Supplies> Save(SuppliesDto entity);
        Task Update(SuppliesDto entity);
        Supplies mapearDatos(Supplies supplies, SuppliesDto entity);
        Task<IEnumerable<SuppliesDto>> GetAll();
    }
}
