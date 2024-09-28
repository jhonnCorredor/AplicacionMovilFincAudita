using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ICityController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<CityDto>>>> GetAll();
        Task<ActionResult<ApiResponse<CityDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] CityDto city);
        Task<ActionResult> Put([FromBody] CityDto city);
        Task<ActionResult> Delete(int id);
    }
}
