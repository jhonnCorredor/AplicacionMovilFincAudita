using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserRoleDto> GetById(int id);
        Task<UserRole> Save(UserRoleDto entity);
        Task Update(UserRoleDto entity);
        UserRole mapearDatos(UserRole userRole, UserRoleDto entity);
        Task<IEnumerable<UserRoleDto>> GetAll();
        Task DeleteRoles(int id);

    }
}
