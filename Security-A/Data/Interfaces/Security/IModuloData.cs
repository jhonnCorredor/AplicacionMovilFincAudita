using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IModuloData
    {

        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Modulo> GetById(int id);
        Task<Modulo> Save(Modulo entity);
        Task Update(Modulo entity);
        Task<Modulo> GetByName(string name);
        Task<IEnumerable<Modulo>> GetAll();
    }
}
