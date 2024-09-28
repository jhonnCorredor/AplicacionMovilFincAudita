using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Operational
{
    public interface ILotTreatmentData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<LotTreatment> GetById(int id);
        Task<LotTreatment> Save(LotTreatment entity);
        Task Update(LotTreatment entity);
        Task DeleteLots(int id);
        Task<IEnumerable<LotTreatment>> GetAll();
    }
}
