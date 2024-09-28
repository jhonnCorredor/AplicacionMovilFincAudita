using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IPersonController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<PersonDto>>>> GetAll();
        Task<ActionResult<ApiResponse<PersonDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] PersonDto person);
        Task<ActionResult> Put([FromBody] PersonDto person);
        Task<ActionResult> Delete(int id);
    }
}
