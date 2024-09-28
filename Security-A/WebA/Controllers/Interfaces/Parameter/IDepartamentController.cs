using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IDepartamentController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<DepartamentDto>>>> GetAll();
        Task<ActionResult<ApiResponse<DepartamentDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] DepartamentDto Departament);
        Task<ActionResult> Put([FromBody] DepartamentDto Departament);
        Task<ActionResult> Delete(int id);
    }
}
