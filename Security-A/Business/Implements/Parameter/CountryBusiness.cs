using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Parameter
{
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryData data;

        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            IEnumerable<Country> countrys = await data.GetAll();
            var CountryDTOs = countrys.Select(Country => new CountryDto
            {
                Id = Country.Id,
                Name = Country.Name,
                Description = Country.Description,
                Code = Country.Code,
                State = Country.State
            });

            return CountryDTOs;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<CountryDto> GetById(int id)
        {
            Country country = await data.GetById(id);
            CountryDto countryDto = new CountryDto();
            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            countryDto.Description = country.Description;
            countryDto.Code = country.Code;
            countryDto.State = country.State;
            return countryDto;
        }

        public Country mapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            country.Description = entity.Description;
            country.Code = entity.Code;
            country.State = entity.State;
            return country;
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = mapearDatos(country, entity);
            country.CreatedAt = DateTime.Now;
            country.State = true;
            country.UpdatedAt = null;
            country.DeletedAt = null;

            return await data.Save(country);
        }

        public async Task Update(CountryDto entity)
        {
            Country country = await data.GetById(entity.Id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = mapearDatos(country, entity);
            country.UpdatedAt = DateTime.Now;

            await data.Update(country);
        }
    }
}
