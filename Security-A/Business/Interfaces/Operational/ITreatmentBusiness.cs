using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Business.Interfaces.Operational
{
    public interface ITreatmentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<TreatmentDto> GetById(int id);
        Task<Treatment> Save(TreatmentDto entity);
        Task Update(TreatmentDto entity);
        Treatment mapearDatos(Treatment treatment, TreatmentDto entity);
        Task<IEnumerable<TreatmentDto>> GetAll();
    }
}
