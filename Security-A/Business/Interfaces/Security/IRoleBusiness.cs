using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleDto> GetById(int id);
        Task<Role> Save(RoleDto entity);
        Task Update(RoleDto entity);
        Role mapearDatos(Role role, RoleDto entity);
        Task<IEnumerable<RoleDto>> GetAll();
    }
}
