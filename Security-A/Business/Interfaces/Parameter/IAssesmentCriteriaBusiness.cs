using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;

namespace Business.Interfaces.Parameter
{
    public interface IAssesmentCriteriaBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<AssesmentCriteriaDto> GetById(int id);
        Task<AssessmentCriteria> Save(AssesmentCriteriaDto entity);
        Task Update(AssesmentCriteriaDto entity);
        AssessmentCriteria mapearDatos(AssessmentCriteria assessmentCriteria, AssesmentCriteriaDto entity);
        Task<IEnumerable<AssesmentCriteriaDto>> GetAll();
    }
}
