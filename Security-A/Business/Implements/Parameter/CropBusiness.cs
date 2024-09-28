using Business.Interfaces.Parameter;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Operational
{
    public class CropBusiness : ICropBusiness
    {
        private readonly ICropData data;

        public CropBusiness(ICropData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<CropDto>> GetAll()
        {
            IEnumerable<Crop> crops = await data.GetAll();
            var cropDtos = crops.Select(crop => new CropDto
            {
                Id = crop.Id,
                Name = crop.Name,
                Description = crop.Description,
                Code = crop.Code,
                State = crop.State
            });

            return cropDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<CropDto> GetById(int id)
        {
            Crop crop = await data.GetById(id);
            CropDto dto = new CropDto();
            dto.Id = crop.Id;
            dto.Name = crop.Name;
            dto.Description = crop.Description;
            dto.Code = crop.Code;
            dto.State = crop.State;
            return dto;
        }

        public Crop mapearDatos(Crop crop, CropDto entity)
        {
            crop.Id = entity.Id;
            crop.Name = entity.Name;
            crop.Description = entity.Description;
            crop.Code = entity.Code;
            crop.State = entity.State;
            return crop;
        }

        public async Task<Crop> Save(CropDto entity)
        {
            Crop crop = new Crop();
            crop = mapearDatos(crop, entity);
            crop.CreatedAt = DateTime.Now;
            crop.State = true;
            crop.UpdatedAt = null;
            crop.DeletedAt = null;

            return await data.Save(crop);
        }

        public async Task Update(CropDto entity)
        {
            Crop crop = await data.GetById(entity.Id);
            if (crop == null)
            {
                throw new Exception("Registro no encontrado");
            }
            crop = mapearDatos(crop, entity);
            crop.UpdatedAt = DateTime.Now;

            await data.Update(crop);
        }
    }
}
