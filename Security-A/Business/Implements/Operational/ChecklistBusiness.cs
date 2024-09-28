using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Business.Implements.Operational
{
    public class ChecklistBusiness : IChecklistBusiness
    {
        private readonly IChecklistData data;
        private readonly IQualificationBusiness qualificationBusiness;

        public ChecklistBusiness(IChecklistData data, IQualificationBusiness qualificationBusiness)
        {
            this.data = data;
            this.qualificationBusiness = qualificationBusiness;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ChecklistDto>> GetAll()
        {
            IEnumerable<Checklist> checklists = await data.GetAll();
            var checklistDtos = checklists.Select(checklist => new ChecklistDto
            {
                Id = checklist.Id,
                Calification_total = checklist.Calification_total,
                Code = checklist.Code,
                State = checklist.State
            });

            return checklistDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ChecklistDto> GetById(int id)
        {
            Checklist checklist = await data.GetById(id);
            ChecklistDto dto = new ChecklistDto();
            dto.Id = checklist.Id;
            dto.Calification_total = checklist.Calification_total;
            dto.Code = checklist.Code;
            dto.State = checklist.State;
            return dto;
        }

        public Checklist mapearDatos(Checklist checklist, ChecklistDto entity)
        {
            checklist.Id = entity.Id;
            checklist.Calification_total = entity.Calification_total;
            checklist.Code = entity.Code;
            checklist.State = (bool)entity.State;
            return checklist;
        }

        public async Task<Checklist> Save(ChecklistDto entity)
        {
            entity.State = true;
            Checklist checklist = new Checklist();
            checklist = mapearDatos(checklist, entity);
            checklist.CreatedAt = DateTime.Now;
            checklist.UpdatedAt = null;
            checklist.DeletedAt = null;

            Checklist save = await data.Save(checklist);

            if (entity.qualifications != null && entity.qualifications.Count > 0)
            {
                foreach (var q in entity.qualifications)
                {
                    QualificationDto dto = new QualificationDto();
                    dto.ChecklistId = save.Id;
                    dto.AssessmentCriteriaId = q.AssessmentCriteriaId;
                    dto.Qualification_criteria = q.Qualification_criteria;
                    dto.Observation = q.Observation;
                    dto.State = true;
                    await qualificationBusiness.Save(dto);
                }
            }

            return save;
        }

        public async Task Update(ChecklistDto entity)
        {
            Checklist checklist = await data.GetById(entity.Id);
            if (checklist == null)
            {
                throw new Exception("Registro no encontrado");
            }
            checklist = mapearDatos(checklist, entity);
            checklist.UpdatedAt = DateTime.Now;

            await data.Update(checklist);
        }
    }
}
