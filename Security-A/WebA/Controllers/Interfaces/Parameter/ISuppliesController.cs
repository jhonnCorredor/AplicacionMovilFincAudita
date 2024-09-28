using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Parameter;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ISuppliesController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<SuppliesDto>>>> GetAll();
        Task<ActionResult<ApiResponse<SuppliesDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] SuppliesDto Supplies);
        Task<ActionResult> Put([FromBody] SuppliesDto Supplies);
        Task<ActionResult> Delete(int id);
    }
}
