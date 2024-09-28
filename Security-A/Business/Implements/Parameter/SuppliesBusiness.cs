using Business.Interfaces.Parameter;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Operational
{
    public class SuppliesBusiness : ISuppliesBusiness
    {
        private readonly ISuppliesData data;

        public SuppliesBusiness(ISuppliesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<SuppliesDto>> GetAll()
        {
            IEnumerable<Supplies> Suppliess = await data.GetAll();
            var SuppliesDtos = Suppliess.Select(Supplies => new SuppliesDto
            {
                Id = Supplies.Id,
                Code = Supplies.Code,
                Name = Supplies.Name,
                Description = Supplies.Description,
                price = Supplies.price,
                State = Supplies.State
            });

            return SuppliesDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<SuppliesDto> GetById(int id)
        {
            Supplies Supplies = await data.GetById(id);
            SuppliesDto dto = new SuppliesDto();
            dto.Id = Supplies.Id;
            dto.Name = Supplies.Name;
            dto.Code = Supplies.Code;
            dto.Description = Supplies.Description;
            dto.price = Supplies.price;
            dto.State = Supplies.State;
            return dto;
        }

        public Supplies mapearDatos(Supplies supplies, SuppliesDto entity)
        {
            supplies.Id = entity.Id;
            supplies.Name = entity.Name;
            supplies.Code = entity.Code;
            supplies.Description = entity.Description;
            supplies.price = entity.price;
            supplies.State = entity.State;
            return supplies;
        }

        public async Task<Supplies> Save(SuppliesDto entity)
        {
            Supplies Supplies = new Supplies();
            Supplies = mapearDatos(Supplies, entity);
            Supplies.CreatedAt = DateTime.Now;
            Supplies.State = true;
            Supplies.UpdatedAt = null;
            Supplies.DeletedAt = null;

            return await data.Save(Supplies);
        }

        public async Task Update(SuppliesDto entity)
        {
            Supplies Supplies = await data.GetById(entity.Id);
            if (Supplies == null)
            {
                throw new Exception("Registro no encontrado");
            }
            Supplies = mapearDatos(Supplies, entity);
            Supplies.UpdatedAt = DateTime.Now;

            await data.Update(Supplies);
        }
    }
}
