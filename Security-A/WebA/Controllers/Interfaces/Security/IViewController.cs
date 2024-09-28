using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IViewController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ViewDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ViewDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ViewDto view);
        Task<ActionResult> Put([FromBody] ViewDto view);
        Task<ActionResult> Delete(int id);
    }
}
