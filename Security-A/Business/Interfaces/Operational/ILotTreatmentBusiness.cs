using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Security;

namespace Business.Interfaces.Operational
{
    public interface ILotTreatmentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<LotTreatmentDto> GetById(int id);
        Task<LotTreatment> Save(LotTreatmentDto entity);
        Task Update(LotTreatmentDto entity);
        Task DeleteLots(int id);
        LotTreatment mapearDatos(LotTreatment LotTreatment, LotTreatmentDto entity);
        Task<IEnumerable<LotTreatmentDto>> GetAll();
    }
}
