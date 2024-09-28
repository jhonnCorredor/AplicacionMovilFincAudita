using Entity.Dto;
using Entity.Model.Parameter;

namespace Data.Interfaces.Parameter
{
    public interface ICountryData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Country> GetById(int id);
        Task<Country> Save(Country entity);
        Task Update(Country entity);
        Task<IEnumerable<Country>> GetAll();
    }
}
