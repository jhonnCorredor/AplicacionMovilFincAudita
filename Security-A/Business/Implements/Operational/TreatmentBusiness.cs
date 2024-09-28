using Business.Interfaces.Operational;
using Business.Interfaces.Parameter;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Dto.Parameter;
using Entity.Model.Operational;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.Json;

namespace Business.Implements.Operational
{
    public class TreatmentBusiness : ITreatmentBusiness
    {
        private readonly ITreatmentData data;
        private readonly ILotTreatmentBusiness ilot;
        private readonly ITreatmentSuppliesBusiness isupplie;

        public TreatmentBusiness(ITreatmentData data, ILotTreatmentBusiness ilot, ITreatmentSuppliesBusiness isupplie)
        {
            this.data = data;
            this.isupplie = isupplie;
            this.ilot = ilot;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<TreatmentDto>> GetAll()
        {
            IEnumerable<TreatmentDto> Treatments = await data.GetAll();
            List<TreatmentDto> TreatmentDtos = new List<TreatmentDto>();
            foreach (var item in Treatments)
            {
                TreatmentDto dto = new TreatmentDto();
                dto.Id = item.Id;
                dto.DateTreatment = item.DateTreatment;
                dto.TypeTreatment = item.TypeTreatment;
                dto.QuantityMix = item.QuantityMix;
                dto.State = item.State;
                if (item.lotString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    dto.lotList = JsonSerializer.Deserialize<List<LotTreatmentDto>>(item.lotString, options);
                }
                if (item.supplieString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    dto.supplieList = JsonSerializer.Deserialize<List<TreatmentSuppliesDto>>(item.supplieString, options);
                }
                TreatmentDtos.Add(dto);
            }

            return TreatmentDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<TreatmentDto> GetById(int id)
        {
            TreatmentDto Treatment = await data.GetByIdPivote(id);
            TreatmentDto dto = new TreatmentDto();
            dto.Id = Treatment.Id;
            dto.DateTreatment = Treatment.DateTreatment;
            dto.QuantityMix = Treatment.QuantityMix;
            dto.TypeTreatment = Treatment.TypeTreatment;
            dto.State = Treatment.State;
            if (Treatment.lotString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                dto.lotList = JsonSerializer.Deserialize<List<LotTreatmentDto>>(Treatment.lotString, options);
            }
            if (Treatment.supplieString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                dto.supplieList = JsonSerializer.Deserialize<List<TreatmentSuppliesDto>>(Treatment.supplieString, options);
            }
            return dto;
        }

        public Treatment mapearDatos(Treatment treatment, TreatmentDto entity)
        {
            treatment.Id = entity.Id;
            treatment.DateTreatment = entity.DateTreatment;
            treatment.QuantityMix = entity.QuantityMix;
            treatment.TypeTreatment = entity.TypeTreatment;
            treatment.State = entity.State;
            return treatment;
        }

        public async Task<Treatment> Save(TreatmentDto entity)
        {
            Treatment Treatment = new Treatment();
            Treatment = mapearDatos(Treatment, entity);
            Treatment.CreatedAt = DateTime.Now;
            Treatment.State = true;
            Treatment.UpdatedAt = null;
            Treatment.DeletedAt = null;

            Treatment tsave = await data.Save(Treatment);

            if (entity.lotList != null &&  entity.lotList.Count > 0)
            {
                foreach (var lote in entity.lotList)
                {
                    LotTreatmentDto lot = new LotTreatmentDto();
                    lot.TreatmentId = tsave.Id;
                    lot.LotId = (int)lote.LotId;
                    lot.State = true;
                    await ilot.Save(lot);
                }
            }

            if(entity.supplieList != null && entity.supplieList.Count > 0)
            {
                foreach (var supplie in entity.supplieList)
                {
                    TreatmentSuppliesDto suplie = new TreatmentSuppliesDto();
                    suplie.TreatmentId = tsave.Id;
                    suplie.SuppliesId = (int)supplie.SuppliesId;
                    suplie.Dose = supplie.Dose;
                    suplie.State = true;
                    await isupplie.Save(suplie);
                }
            }

            return tsave;
        }

        public async Task Update(TreatmentDto entity)
        {
            Treatment Treatment = await data.GetById(entity.Id);
            if (Treatment == null)
            {
                throw new Exception("Registro no encontrado");
            }
            Treatment = mapearDatos(Treatment, entity);
            Treatment.UpdatedAt = DateTime.Now;

            await data.Update(Treatment);

            await ilot.DeleteLots(Treatment.Id);

            if (entity.lotList != null && entity.lotList.Count > 0)
            {
                foreach (var lote in entity.lotList)
                {
                    LotTreatmentDto lot = new LotTreatmentDto();
                    lot.TreatmentId = Treatment.Id;
                    lot.LotId = (int)lote.LotId;
                    lot.State = true;
                    await ilot.Save(lot);
                }
            }

            await isupplie.DeleteSupplie(Treatment.Id);

            if (entity.supplieList != null && entity.supplieList.Count > 0)
            {
                foreach (var supplie in entity.supplieList)
                {
                    TreatmentSuppliesDto suplie = new TreatmentSuppliesDto();
                    suplie.TreatmentId = Treatment.Id;
                    suplie.SuppliesId = (int)supplie.SuppliesId;
                    suplie.Dose = supplie.Dose;
                    suplie.State = true;
                    await isupplie.Save(suplie);
                }
            }

        }
    }
}
