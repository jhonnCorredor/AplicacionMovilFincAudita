using Business.Interfaces.Parameter;
using Data.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Implements.Operational
{
    public class AssesmentCriteriaBusiness : IAssesmentCriteriaBusiness
    {
        private readonly IAssesmentCriteriaData data;

        public AssesmentCriteriaBusiness(IAssesmentCriteriaData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<AssesmentCriteriaDto>> GetAll()
        {
            IEnumerable<AssessmentCriteria> criterias = await data.GetAll();
            var criteriaDtos = criterias.Select(criteria => new AssesmentCriteriaDto
            {
                Id = criteria.Id,
                Name = criteria.Name,
                Rating_range = criteria.Rating_range,
                Type_criterian = criteria.Type_criterian,
                State = criteria.State
            });

            return criteriaDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<AssesmentCriteriaDto> GetById(int id)
        {
            AssessmentCriteria criteria = await data.GetById(id);
            AssesmentCriteriaDto criteriaDto = new AssesmentCriteriaDto();
            criteriaDto.Id = criteria.Id;
            criteriaDto.Type_criterian = criteria.Type_criterian;
            criteriaDto.Rating_range = criteria.Rating_range;
            criteriaDto.Name = criteria.Name;
            criteriaDto.State = criteria.State;
            return criteriaDto;
        }

        public AssessmentCriteria mapearDatos(AssessmentCriteria assessmentCriteria, AssesmentCriteriaDto entity)
        {
            assessmentCriteria.Id = entity.Id;
            assessmentCriteria.Type_criterian = entity.Type_criterian;
            assessmentCriteria.Rating_range = entity.Rating_range;
            assessmentCriteria.Name = entity.Name;
            assessmentCriteria.State = entity.State;
            return assessmentCriteria;
        }

        public async Task<AssessmentCriteria> Save(AssesmentCriteriaDto entity)
        {
            AssessmentCriteria assessmentCriteria = new AssessmentCriteria();
            assessmentCriteria = mapearDatos(assessmentCriteria, entity);
            assessmentCriteria.CreatedAt = DateTime.Now;
            assessmentCriteria.State = true;
            assessmentCriteria.UpdatedAt = null;
            assessmentCriteria.DeletedAt = null;

            return await data.Save(assessmentCriteria);
        }

        public async Task Update(AssesmentCriteriaDto entity)
        {
            AssessmentCriteria assessmentCriteria = await data.GetById(entity.Id);
            if (assessmentCriteria == null)
            {
                throw new Exception("Registro no encontrado");
            }
            assessmentCriteria = mapearDatos(assessmentCriteria, entity);
            assessmentCriteria.UpdatedAt = DateTime.Now;

            await data.Update(assessmentCriteria);
        }
    }
}
