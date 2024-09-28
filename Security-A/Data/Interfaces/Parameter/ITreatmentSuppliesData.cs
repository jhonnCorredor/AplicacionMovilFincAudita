using Entity.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface ITreatmentSuppliesData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<TreatmentSupplies> GetById(int id);
        Task<TreatmentSupplies> Save(TreatmentSupplies entity);
        Task Update(TreatmentSupplies entity);
        Task<IEnumerable<TreatmentSupplies>> GetAll();
        Task DeleteSupplie(int id);
    }
}
