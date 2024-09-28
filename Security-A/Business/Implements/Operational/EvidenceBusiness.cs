using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Business.Implements.Operational
{
    public class EvidenceBusiness : IEvidenceBusiness
    {
        private readonly IEvidenceData data;

        public EvidenceBusiness(IEvidenceData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task DeleteEvidences(int id)
        {
            await data.DeleteEvidences(id);
        }

        public async Task<IEnumerable<EvidenceDto>> GetAll()
        {
            IEnumerable<Evidence> evidences = await data.GetAll();
            var evidenceDtos = evidences.Select(evidence => new EvidenceDto
            {
                Id = evidence.Id,
                Code = evidence.Code,
                Document = evidence.Document,
                ReviewId = evidence.ReviewId,
                State = evidence.State
            });

            return evidenceDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<EvidenceDto> GetById(int id)
        {
            Evidence evidence = await data.GetById(id);
            EvidenceDto dto = new EvidenceDto();
            dto.Id = evidence.Id;
            dto.Document = evidence.Document;
            dto.Code = evidence.Code;
            dto.ReviewId = evidence.ReviewId;
            dto.State = evidence.State;
            return dto;
        }

        public Evidence mapearDatos(Evidence evidence, EvidenceDto entity)
        {
            evidence.Id = entity.Id;
            evidence.Document = entity.Document;
            evidence.Code = entity.Code;
            evidence.ReviewId = (int)entity.ReviewId;
            evidence.State = (bool)entity.State;
            return evidence;
        }

        public async Task<Evidence> Save(EvidenceDto entity)
        {
            Evidence evidence = new Evidence();
            evidence = mapearDatos(evidence, entity);
            evidence.CreatedAt = DateTime.Now;
            evidence.State = true;
            evidence.UpdatedAt = null;
            evidence.DeletedAt = null;

            return await data.Save(evidence);
        }

        public async Task Update(EvidenceDto entity)
        {
            Evidence evidence = await data.GetById(entity.Id);
            if (evidence == null)
            {
                throw new Exception("Registro no encontrado");
            }
            evidence = mapearDatos(evidence, entity);
            evidence.UpdatedAt = DateTime.Now;

            await data.Update(evidence);
        }
    }
}
