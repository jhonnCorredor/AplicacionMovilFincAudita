using Business.Interfaces.Operational;
using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Evidence")]
    [ApiController]
    public class EvidenceController : ControllerBase, IEvidenceController
    {
        private readonly IEvidenceBusiness business;

        public EvidenceController(IEvidenceBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EvidenceDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EvidenceDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EvidenceDto Evidence)
        {
            if (Evidence == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Evidence);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EvidenceDto Evidence)
        {
            if (Evidence == null)
            {
                return BadRequest();
            }
            await business.Update(Evidence);
            return NoContent();
        }
    }
}
