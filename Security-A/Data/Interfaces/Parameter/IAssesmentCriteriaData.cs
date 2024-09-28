using Entity.Dto;
using Entity.Model.Parameter;

namespace Data.Interfaces.Operational
{
    public interface IAssesmentCriteriaData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<AssessmentCriteria> GetById(int id);
        Task<AssessmentCriteria> Save(AssessmentCriteria entity);
        Task Update(AssessmentCriteria entity);
        Task<IEnumerable<AssessmentCriteria>> GetAll();
    }
}

