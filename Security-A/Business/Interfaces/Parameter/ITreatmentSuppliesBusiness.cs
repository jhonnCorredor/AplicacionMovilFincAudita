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
    public interface ITreatmentSuppliesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<TreatmentSuppliesDto> GetById(int id);
        Task DeleteSupplie(int id);

        Task<TreatmentSupplies> Save(TreatmentSuppliesDto entity);
        Task Update(TreatmentSuppliesDto entity);
        TreatmentSupplies mapearDatos(TreatmentSupplies TreatmentSupplies, TreatmentSuppliesDto entity);
        Task<IEnumerable<TreatmentSuppliesDto>> GetAll();
    }
}
