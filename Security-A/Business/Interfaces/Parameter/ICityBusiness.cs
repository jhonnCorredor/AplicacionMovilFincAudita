using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Interfaces.Parameter
{
    public interface ICityBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(CityDto entity);
        City mapearDatos(City city, CityDto entity);
        Task<IEnumerable<CityDto>> GetAll();
    }
}
