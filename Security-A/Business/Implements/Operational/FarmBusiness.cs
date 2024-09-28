using Business.Implements.Security;
using Business.Interfaces.Operational;
using Data.Implements.Operational;
using Data.Implements.Security;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Dto.Security;
using Entity.Model.Operational;
using Entity.Model.Security;
using System.Data;
using System.Text.Json;

namespace Business.Implements.Operational
{
    public class FarmBusiness : IFarmBusiness
    {
        private readonly IFarmData data;
        private readonly ILotBusiness ILotBusiness;

        public FarmBusiness(IFarmData data, ILotBusiness iLotBusiness)
        {
            this.data = data;
            ILotBusiness = iLotBusiness;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<FarmDto>> GetAll()
        {
            IEnumerable<FarmDto> farms = await data.GetAll();
            List<FarmDto> FarmDtos= new List<FarmDto>();
            foreach (var farm in farms)
            {
                FarmDto finca = new FarmDto();
                finca.Id = farm.Id;
                finca.CityId = (int)farm.CityId;
                finca.UserId = (int)farm.UserId;
                finca.Addres = farm.Addres;
                finca.Dimension = farm.Dimension;
                finca.Name = farm.Name;
                finca.State = farm.State;
                if (farm.lotString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    finca.Lots = JsonSerializer.Deserialize<List<LotDto>>(farm.lotString, options);
                }
                FarmDtos.Add(finca);
            }

            return FarmDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<FarmDto> GetById(int id)
        {
            FarmDto farm = await data.GetByIdLot(id);
            FarmDto farmDto = new FarmDto();
            farmDto.Id = farm.Id;
            farmDto.CityId = (int)farm.CityId;
            farmDto.UserId = (int)farm.UserId;
            farmDto.Addres = farm.Addres;
            farmDto.Dimension = farm.Dimension;
            farmDto.Name = farm.Name;
            farmDto.State = farm.State;
            if (farm.lotString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                farmDto.Lots = JsonSerializer.Deserialize<List<LotDto>>(farm.lotString, options);
            }
            return farmDto;
        }

        public Farm mapearDatos(Farm farm, FarmDto entity)
        {
            farm.Id = entity.Id;
            farm.CityId = entity.CityId;
            farm.UserId = entity.UserId;
            farm.Name = entity.Name;
            farm.Addres = entity.Addres;
            farm.Dimension = entity.Dimension;
            farm.State = entity.State;
            return farm;    
        }

        public async Task<Farm> Save(FarmDto entity)
        {
            Farm farm = new Farm();
            farm = mapearDatos(farm, entity);
            farm.CreatedAt = DateTime.Now;
            farm.UpdatedAt = null;
            farm.DeletedAt = null;

            Farm farmSave = await data.Save(farm);

            if (entity.Lots != null && entity.Lots.Count > 0)
            {
                foreach (var lote in entity.Lots)
                {
                    LotDto lot = new LotDto();
                    lot.FarmId = farmSave.Id;
                    lot.CropId = (int)lote.CropId;
                    lot.Num_hectareas = lote.Num_hectareas;
                    lot.State = true;
                    await ILotBusiness.Save(lot);
                }
            }

            return farmSave;
        }

        public async Task Update(FarmDto entity)
        {
            Farm farm = await data.GetById(entity.Id);
            if (farm == null)
            {
                throw new Exception("Registro no encontrado");
            }
            farm = mapearDatos(farm, entity);
            farm.UpdatedAt = DateTime.Now;

            await ILotBusiness.DeleteLots(farm.Id);

            if (entity.Lots != null && entity.Lots.Count > 0)
            {
                foreach (var lote in entity.Lots)
                {
                    LotDto lot = new LotDto();
                    lot.FarmId = farm.Id;
                    lot.CropId = (int)lote.CropId;
                    lot.Num_hectareas = lote.Num_hectareas;
                    lot.State = true;
                    await ILotBusiness.Save(lot);
                }
            }

            await data.Update(farm);
        }
    }
}
