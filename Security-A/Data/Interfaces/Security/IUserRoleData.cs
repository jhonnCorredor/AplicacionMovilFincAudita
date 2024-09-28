using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IUserRoleData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRole entity);
        Task Update(UserRole entity);
        Task DeleteRoles(int id);

        Task<IEnumerable<UserRole>> GetAll();
    }
}
