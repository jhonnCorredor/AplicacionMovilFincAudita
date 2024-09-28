using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Parameter;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ITreatmentSuppliesController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<TreatmentSuppliesDto>>>> GetAll();
        Task<ActionResult<ApiResponse<TreatmentSuppliesDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] TreatmentSuppliesDto TreatmentSupplies);
        Task<ActionResult> Put([FromBody] TreatmentSuppliesDto TreatmentSupplies);
        Task<ActionResult> Delete(int id);
    }
}
