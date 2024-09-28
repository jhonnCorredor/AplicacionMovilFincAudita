using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IQualificationController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<QualificationDto>>>> GetAll();
        Task<ActionResult<ApiResponse<QualificationDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] QualificationDto Qualification);
        Task<ActionResult> Put([FromBody] QualificationDto Qualification);
        Task<ActionResult> Delete(int id);
    }
}
