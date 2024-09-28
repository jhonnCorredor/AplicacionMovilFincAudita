using Entity.Dto;
using Entity.Model.Parameter;

namespace Data.Interfaces.Parameter
{
    public interface ICityData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<City> GetById(int id);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<IEnumerable<City>> GetAll();
    }
}
