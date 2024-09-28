using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Interfaces.Parameter
{
    public interface IDepartamentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<DepartamentDto> GetById(int id);
        Task<Departament> Save(DepartamentDto entity);
        Task Update(DepartamentDto entity);
        Departament mapearDatos(Departament departament, DepartamentDto entity);
        Task<IEnumerable<DepartamentDto>> GetAll();
    }
}
