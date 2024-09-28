using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IAlertController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<AlertDto>>>> GetAll();
        Task<ActionResult<ApiResponse<IEnumerable<AlertDto>>>> GetByUser([FromBody] DataSelectDto Alert);
        Task<ActionResult<ApiResponse<AlertDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] AlertDto Alert);
        Task<ActionResult> Put([FromBody] AlertDto Alert);
        Task<ActionResult> Delete(int id);
    }
}
