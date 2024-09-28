using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Data.Interfaces.Operational
{
    public interface ITreatmentData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Treatment> GetById(int id);
        Task<Treatment> Save(Treatment entity);
        Task Update(Treatment entity);
        Task<TreatmentDto> GetByIdPivote(int id);
        Task<IEnumerable<TreatmentDto>> GetAll();
    }
}
