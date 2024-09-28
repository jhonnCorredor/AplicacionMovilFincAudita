using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Parameter;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ICropController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<CropDto>>>> GetAll();
        Task<ActionResult<ApiResponse<CropDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] CropDto Crop);
        Task<ActionResult> Put([FromBody] CropDto Crop);
        Task<ActionResult> Delete(int id);
    }
}
