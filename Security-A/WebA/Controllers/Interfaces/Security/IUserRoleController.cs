using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IUserRoleController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<UserRoleDto>>>> GetAll();
        Task<ActionResult<ApiResponse<UserRoleDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] UserRoleDto userRole);
        Task<ActionResult> Put([FromBody] UserRoleDto userRole);
        Task<ActionResult> Delete(int id);
    }
}
