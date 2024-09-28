using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IChecklistController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ChecklistDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ChecklistDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ChecklistDto Checklist);
        Task<ActionResult> Put([FromBody] ChecklistDto Checklist);
        Task<ActionResult> Delete(int id);
    }
}
