using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IViewData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<View> GetById(int id);
        Task<View> Save(View entity);
        Task Update(View entity);
        Task<View> GetByName(string name);
        Task<IEnumerable<View>> GetAll();
    }
}
