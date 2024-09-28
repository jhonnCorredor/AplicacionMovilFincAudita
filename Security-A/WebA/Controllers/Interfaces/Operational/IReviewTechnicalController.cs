using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IReviewTechnicalController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ReviewTechnicalDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ReviewTechnicalDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ReviewTechnicalDto ReviewTechnical);
        Task<ActionResult> Put([FromBody] ReviewTechnicalDto ReviewTechnical);
        Task<ActionResult> Delete(int id);
    }
}
