using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dto.Operational;
using Entity.Dto;
using Entity.Model.Operational;
using System.Text.Json;
using System;
using System.Security.Principal;

namespace Business.Implements.Operational
{
    public class ReviewTechnicalBusiness : IReviewTechnicalBusiness
    {
        private readonly IReviewTechnicalData data;
        private readonly IEvidenceBusiness evidenceBusiness;
        private readonly IChecklistBusiness checklistBusiness;

        public ReviewTechnicalBusiness(IReviewTechnicalData data, IEvidenceBusiness evidenceBusiness, IChecklistBusiness checklistBusiness)
        {
            this.data = data;
            this.evidenceBusiness = evidenceBusiness;
            this.checklistBusiness = checklistBusiness;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ReviewTechnicalDto>> GetAll()
        {
            IEnumerable<ReviewTechnicalDto> ReviewTechnicals = await data.GetAll();
            List<ReviewTechnicalDto> ReviewTechnicalDtos = new List<ReviewTechnicalDto>();
            foreach(var item in ReviewTechnicals)
            {
                ReviewTechnicalDto dto = new ReviewTechnicalDto();
                dto.Id = item.Id;
                dto.ChecklistId = item.ChecklistId;
                dto.LotId = item.LotId;
                dto.TecnicoId = item.TecnicoId;
                dto.Tecnico = item.Tecnico;
                dto.lot = item.lot;
                dto.Code = item.Code;
                dto.Date_review = item.Date_review;
                dto.Observation = item.Observation;
                dto.State = item.State;
                if (item.evidenceString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    dto.evidences = JsonSerializer.Deserialize<List<EvidenceDto>>(item.evidenceString, options);
                }
                if (item.checklistString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    dto.checklists = JsonSerializer.Deserialize<ChecklistDto>(item.checklistString, options);
                }
                ReviewTechnicalDtos.Add(dto);
            }

            return ReviewTechnicalDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ReviewTechnicalDto> GetById(int id)
        {
            ReviewTechnicalDto ReviewTechnical = await data.GetByIdPivote(id);
            ReviewTechnicalDto dto = new ReviewTechnicalDto();
            dto.Id = ReviewTechnical.Id;
            dto.ChecklistId = ReviewTechnical.ChecklistId;
            dto.LotId = ReviewTechnical.LotId;
            dto.Tecnico = ReviewTechnical.Tecnico;
            dto.lot = ReviewTechnical.lot;
            dto.Code = ReviewTechnical.Code;
            dto.Date_review = ReviewTechnical.Date_review;
            dto.LotId = ReviewTechnical.LotId;
            dto.Observation = ReviewTechnical.Observation;
            dto.TecnicoId= ReviewTechnical.TecnicoId;
            dto.State = ReviewTechnical.State;
            if (ReviewTechnical.evidenceString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                dto.evidences = JsonSerializer.Deserialize<List<EvidenceDto>>(ReviewTechnical.evidenceString, options);
            }
            if (ReviewTechnical.checklistString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                dto.checklists = JsonSerializer.Deserialize<ChecklistDto>(ReviewTechnical.checklistString, options);
            }
            return dto;
        }

        public ReviewTechnical mapearDatos(ReviewTechnical reviewTechnical, ReviewTechnicalDto entity)
        {
            reviewTechnical.Id = entity.Id;
            reviewTechnical.ChecklistId = entity.ChecklistId;
            reviewTechnical.Code = entity.Code;
            reviewTechnical.Date_review = entity.Date_review;
            reviewTechnical.LotId = entity.LotId;
            reviewTechnical.Observation = entity.Observation;
            reviewTechnical.TecnicoId = entity.TecnicoId;
            reviewTechnical.State = entity.State;
            return reviewTechnical;
        }

        public async Task<ReviewTechnical> Save(ReviewTechnicalDto entity)
        {
            Checklist cId = new Checklist();
            if (entity.checklists != null )
            {
                    cId = await checklistBusiness.Save(entity.checklists);
            }

            entity.ChecklistId = cId.Id;

            ReviewTechnical ReviewTechnical = new ReviewTechnical();
            ReviewTechnical = mapearDatos(ReviewTechnical, entity);
            ReviewTechnical.CreatedAt = DateTime.Now;
            ReviewTechnical.State = true;
            ReviewTechnical.UpdatedAt = null;
            ReviewTechnical.DeletedAt = null;

            ReviewTechnical save = await data.Save(ReviewTechnical);

            if (entity.evidences != null && entity.evidences.Count>0)
            {
                foreach (var dto in entity.evidences)
                {
                    EvidenceDto evidence = new EvidenceDto();
                    evidence.Code = dto.Code;
                    evidence.Document = dto.Document;
                    evidence.ReviewId = save.Id;
                    evidence.State = true;
                    await evidenceBusiness.Save(evidence);
                }
            }

            return save;
        }

        public async Task Update(ReviewTechnicalDto entity)
        {
            ReviewTechnical ReviewTechnical = await data.GetById(entity.Id);

            if (ReviewTechnical == null)
            {
                throw new Exception("Registro no encontrado");
            }

            Checklist cId = new Checklist();
            if (entity.checklists != null)
            {
                cId = await checklistBusiness.Save(entity.checklists);
            }

            ReviewTechnical = mapearDatos(ReviewTechnical, entity);
            ReviewTechnical.ChecklistId = cId.Id;
            ReviewTechnical.UpdatedAt = DateTime.Now;

            await evidenceBusiness.DeleteEvidences(ReviewTechnical.Id);

            if (entity.evidences != null && entity.evidences.Count > 0)
            {
                foreach (var dto in entity.evidences)
                {
                    EvidenceDto evidence = new EvidenceDto();
                    evidence.Code = dto.Code;
                    evidence.Document = dto.Document;
                    evidence.ReviewId = ReviewTechnical.Id;
                    evidence.State = true;
                    await evidenceBusiness.Save(evidence);
                }
            }

            await data.Update(ReviewTechnical);
        }
    }
}
