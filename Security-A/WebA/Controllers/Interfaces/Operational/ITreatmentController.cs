using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface ITreatmentController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<TreatmentDto>>>> GetAll();
        Task<ActionResult<ApiResponse<TreatmentDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] TreatmentDto Treatment);
        Task<ActionResult> Put([FromBody] TreatmentDto Treatment);
        Task<ActionResult> Delete(int id);
    }
}
