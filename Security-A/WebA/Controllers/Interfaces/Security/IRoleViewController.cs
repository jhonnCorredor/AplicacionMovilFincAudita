using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IRoleViewController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<RoleViewDto>>>> GetAll();
        Task<ActionResult<ApiResponse<RoleViewDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] RoleViewDto roleView);
        Task<ActionResult> Put([FromBody] RoleViewDto roleView);
        Task<ActionResult> Delete(int id);
    }
}
