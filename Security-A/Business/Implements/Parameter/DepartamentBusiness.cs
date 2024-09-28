using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Parameter
{
    public class DepartamentBusiness : IDepartamentBusiness
    {
        private readonly IDepartamentData data;

        public DepartamentBusiness(IDepartamentData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DepartamentDto>> GetAll()
        {
            IEnumerable<Departament> departaments = await data.GetAll();
            var departamentDTOs = departaments.Select(departament => new DepartamentDto
            {
                Id = departament.Id,
                Name = departament.Name,
                Description = departament.Description,
                Code = departament.Code,
                State = departament.State,
                CountryId = departament.CountryId
            });

            return departamentDTOs;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<DepartamentDto> GetById(int id)
        {
            Departament departament = await data.GetById(id);
            DepartamentDto Dto = new DepartamentDto();
            Dto.Id = departament.Id;
            Dto.Name = departament.Name;
            Dto.Description = departament.Description;
            Dto.Code = departament.Code;
            Dto.CountryId = departament.CountryId;
            Dto.State = departament.State;
            return Dto;
        }

        public Departament mapearDatos(Departament departament, DepartamentDto entity)
        {
            departament.Id = entity.Id;
            departament.Name = entity.Name;
            departament.Description = entity.Description;
            departament.Code = entity.Code;
            departament.CountryId = entity.CountryId;
            departament.State = entity.State;
            return departament;
        }

        public async Task<Departament> Save(DepartamentDto entity)
        {
            Departament departament = new Departament();
            departament = mapearDatos(departament, entity);
            departament.CreatedAt = DateTime.Now;
            departament.State = true;
            departament.UpdatedAt = null;
            departament.DeletedAt = null;

            return await data.Save(departament);
        }

        public async Task Update(DepartamentDto entity)
        {
            Departament departament = await data.GetById(entity.Id);
            if (departament == null)
            {
                throw new Exception("Registro no encontrado");
            }
            departament = mapearDatos(departament, entity);
            departament.UpdatedAt = DateTime.Now;

            await data.Update(departament);
        }
    }
}
