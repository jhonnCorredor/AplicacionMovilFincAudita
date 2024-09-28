using Microsoft.AspNetCore.Mvc;
using Entity.Dto;
using Entity.Dto.Security;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IUserController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAll();
        Task<ActionResult<ApiResponse<UserDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] UserDto user);
        Task<ActionResult> Put([FromBody] UserDto user);
        Task<ActionResult> Delete(int id);
        Task<ActionResult> Login(AuthenticationDto dto);
    }
}
