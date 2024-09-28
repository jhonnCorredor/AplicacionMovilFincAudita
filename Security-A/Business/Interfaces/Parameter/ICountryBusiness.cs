using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Interfaces.Parameter
{
    public interface ICountryBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<CountryDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<CountryDto> GetById(int id);
        Task<Country> Save(CountryDto entity);
        Task Update( CountryDto entity);
        Country mapearDatos(Country country, CountryDto entity);
    }
}
