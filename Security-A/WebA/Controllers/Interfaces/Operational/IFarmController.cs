using Entity.Dto;
using Entity.Dto.Operational;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IFarmController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<FarmDto>>>> GetAll();
        Task<ActionResult<ApiResponse<FarmDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] FarmDto farm);
        Task<ActionResult> Put([FromBody] FarmDto farm);
        Task<ActionResult> Delete(int id);
    }
}
