using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Implements.Security
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IModuloData data;

        public ModuloBusiness(IModuloData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            IEnumerable<Modulo> modulos = await data.GetAll();
            var moduloDtos = modulos.Select(modulo => new ModuloDto
            {
                Id = modulo.Id,
                Name = modulo.Name,
                Description = modulo.Description,
                Position = modulo.Position,
                State = modulo.State
            });

            return moduloDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await data.GetById(id);
            ModuloDto ModuloDto = new ModuloDto();

            ModuloDto.Id = modulo.Id;
            ModuloDto.Name = modulo.Name;
            ModuloDto.Description = modulo.Description;
            ModuloDto.Position = modulo.Position;
            ModuloDto.State = modulo.State;
            return ModuloDto;
        }

        public Modulo mapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.Name = entity.Name;
            modulo.Description = entity.Description;
            modulo.Position = entity.Position;
            modulo.State = entity.State;
            return modulo;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo = mapearDatos(modulo, entity);
            modulo.CreatedAt = DateTime.Now;
            modulo.State = true;
            modulo.DeletedAt = null;
            modulo.UpdatedAt = null;


            return await data.Save(modulo);
        }

        public async Task Update(ModuloDto entity)
        {
            Modulo modulo = await data.GetById(entity.Id);
            if (modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = mapearDatos(modulo, entity);
            modulo.UpdatedAt = DateTime.Now;

            await data.Update(modulo);
        }
    }
}
