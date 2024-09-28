using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Parameter;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IAssesmentCriteriaController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<AssesmentCriteriaDto>>>> GetAll();
        Task<ActionResult<ApiResponse<AssesmentCriteriaDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] AssesmentCriteriaDto AssesmentCriteria);
        Task<ActionResult> Put([FromBody] AssesmentCriteriaDto AssesmentCriteria);
        Task<ActionResult> Delete(int id);
    }
}
