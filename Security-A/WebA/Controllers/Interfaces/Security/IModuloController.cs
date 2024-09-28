using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IModuloController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ModuloDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ModuloDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ModuloDto modulo);
        Task<ActionResult> Put([FromBody] ModuloDto modulo);
        Task<ActionResult> Delete(int id);
    }
}

