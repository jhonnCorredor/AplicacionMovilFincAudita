using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Business.Interfaces.Operational
{
    public interface IChecklistBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ChecklistDto> GetById(int id);
        Task<Checklist> Save(ChecklistDto entity);
        Task Update(ChecklistDto entity);
        Checklist mapearDatos(Checklist checklist, ChecklistDto entity);
        Task<IEnumerable<ChecklistDto>> GetAll();
    }
}
