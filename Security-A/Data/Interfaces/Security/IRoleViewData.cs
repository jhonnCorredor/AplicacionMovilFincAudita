using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IRoleViewData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleView> GetById(int id);
        Task<RoleView> Save(RoleView entity);
        Task Update(RoleView entity);
        Task DeleteViews(int id);
        Task<IEnumerable<RoleView>> GetAll();
    }
}
