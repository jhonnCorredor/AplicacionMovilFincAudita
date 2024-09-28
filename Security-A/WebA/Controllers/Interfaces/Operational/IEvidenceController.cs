using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IEvidenceController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<EvidenceDto>>>> GetAll();
        Task<ActionResult<ApiResponse<EvidenceDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] EvidenceDto Evidence);
        Task<ActionResult> Put([FromBody] EvidenceDto Evidence);
        Task<ActionResult> Delete(int id);
    }
}
