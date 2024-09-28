using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface ILotController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<LotDto>>>> GetAll();
        Task<ActionResult<ApiResponse<LotDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] LotDto lot);
        Task<ActionResult> Put([FromBody] LotDto lot);
        Task<ActionResult> Delete(int id);
    }
}
