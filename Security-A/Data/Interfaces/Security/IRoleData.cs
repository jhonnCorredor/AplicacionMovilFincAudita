using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<RoleDto> GetByIdAndViews(int id);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<Role> GetByName(string name);
    }
}
