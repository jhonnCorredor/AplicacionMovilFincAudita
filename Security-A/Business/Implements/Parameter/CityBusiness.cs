using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Parameter
{
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityData data;

        public CityBusiness(ICityData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            IEnumerable<City> citys = await data.GetAll();
            var CityDTOs = citys.Select(City => new CityDto
            {
                Id = City.Id,
                Name = City.Name,
                Description = City.Description,
                Code = City.Code,
                State = City.State,
                DepartamentId = City.DepartamentId
            });

            return CityDTOs;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<CityDto> GetById(int id)
        {
            City city = await data.GetById(id);
            CityDto CityDto = new CityDto();
            CityDto.Id = city.Id;
            CityDto.Name = city.Name;
            CityDto.Description = city.Description;
            CityDto.Code = city.Code;
            CityDto.DepartamentId = city.DepartamentId;
            CityDto.State = city.State;
            return CityDto;
        }

        public City mapearDatos(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.Name = entity.Name;
            city.Description = entity.Description;
            city.Code = entity.Code;
            city.DepartamentId = entity.DepartamentId;
            city.State = entity.State;
            return city;
        }

        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city = mapearDatos(city, entity);
            city.CreatedAt = DateTime.Now;
            city.State = true;
            city.UpdatedAt = null;
            city.DeletedAt = null;

            return await data.Save(city);
        }

        public async Task Update(CityDto entity)
        {
            City city = await data.GetById(entity.Id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = mapearDatos(city, entity);
            city.UpdatedAt = DateTime.Now;

            await data.Update(city);
        }
    }
}
