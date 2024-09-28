using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface ILotTreatmentController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<LotTreatmentDto>>>> GetAll();
        Task<ActionResult<ApiResponse<LotTreatmentDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] LotTreatmentDto LotTreatment);
        Task<ActionResult> Put([FromBody] LotTreatmentDto LotTreatment);
        Task<ActionResult> Delete(int id);
    }
}
