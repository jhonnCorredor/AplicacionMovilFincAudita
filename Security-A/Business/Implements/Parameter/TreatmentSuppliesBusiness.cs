using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Business.Interfaces.Parameter;

namespace Business.Implements.Operational
{
    public class TreatmentSuppliesBusiness : ITreatmentSuppliesBusiness
    {
        private readonly ITreatmentSuppliesData data;

        public TreatmentSuppliesBusiness(ITreatmentSuppliesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }
        public async Task DeleteSupplie(int id)
        {
            await data.DeleteSupplie(id);
        }

        public async Task<IEnumerable<TreatmentSuppliesDto>> GetAll()
        {
            IEnumerable<TreatmentSupplies> TreatmentSuppliess = await data.GetAll();
            var TreatmentSuppliesDtos = TreatmentSuppliess.Select(TreatmentSupplies => new TreatmentSuppliesDto
            {
                Id = TreatmentSupplies.Id,
                Dose = TreatmentSupplies.Dose,
                TreatmentId = TreatmentSupplies.TreatmentId,
                SuppliesId = TreatmentSupplies.SuppliesId,
                State = TreatmentSupplies.State
            });

            return TreatmentSuppliesDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<TreatmentSuppliesDto> GetById(int id)
        {
            TreatmentSupplies TreatmentSupplies = await data.GetById(id);
            TreatmentSuppliesDto dto = new TreatmentSuppliesDto();
            dto.Id = TreatmentSupplies.Id;
            dto.SuppliesId = TreatmentSupplies.SuppliesId;
            dto.TreatmentId = TreatmentSupplies.TreatmentId;
            dto.Dose = TreatmentSupplies.Dose;
            dto.State = TreatmentSupplies.State;
            return dto;
        }

        public TreatmentSupplies mapearDatos(TreatmentSupplies TreatmentSupplies, TreatmentSuppliesDto entity)
        {
            TreatmentSupplies.Id = entity.Id;
            TreatmentSupplies.SuppliesId = (int)entity.SuppliesId;
            TreatmentSupplies.TreatmentId = (int)entity.TreatmentId;
            TreatmentSupplies.Dose = entity.Dose;
            TreatmentSupplies.State = (bool)entity.State;
            return TreatmentSupplies;
        }

        public async Task<TreatmentSupplies> Save(TreatmentSuppliesDto entity)
        {
            TreatmentSupplies TreatmentSupplies = new TreatmentSupplies();
            TreatmentSupplies = mapearDatos(TreatmentSupplies, entity);
            TreatmentSupplies.CreatedAt = DateTime.Now;
            TreatmentSupplies.State = true;
            TreatmentSupplies.UpdatedAt = null;
            TreatmentSupplies.DeletedAt = null;

            return await data.Save(TreatmentSupplies);
        }

        public async Task Update(TreatmentSuppliesDto entity)
        {
            TreatmentSupplies TreatmentSupplies = await data.GetById(entity.Id);
            if (TreatmentSupplies == null)
            {
                throw new Exception("Registro no encontrado");
            }
            TreatmentSupplies = mapearDatos(TreatmentSupplies, entity);
            TreatmentSupplies.UpdatedAt = DateTime.Now;

            await data.Update(TreatmentSupplies);
        }
    }
}
