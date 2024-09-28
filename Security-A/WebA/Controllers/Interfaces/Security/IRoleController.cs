using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IRoleController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<RoleDto>>>> GetAll();
        Task<ActionResult<ApiResponse<RoleDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] RoleDto role);
        Task<ActionResult> Put([FromBody] RoleDto role);
        Task<ActionResult> Delete(int id);
    }
}
