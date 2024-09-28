using Business.Interfaces.Security;
using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;
using WebA.Controllers.Interfaces.Operational;
using Business.Interfaces.Operational;
using Entity.Dto.Operational;

namespace WebA.Controllers.Implements.Operational
{
        [Route("api/LotTreatment")]
        [ApiController]
        public class LotTreatmentController : ControllerBase, ILotTreatmentController
        {
            protected readonly ILotTreatmentBusiness business;

            public LotTreatmentController(ILotTreatmentBusiness business)
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
            public async Task<ActionResult<ApiResponse<LotTreatmentDto>>> Get(int id)
            {
                var result = await business.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpGet]
            public async Task<ActionResult<ApiResponse<IEnumerable<LotTreatmentDto>>>> GetAll()
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
            public async Task<ActionResult> Post([FromBody] LotTreatmentDto LotTreatment)
            {
                if (LotTreatment == null)
                {
                    return BadRequest("Entity is null");
                }
                var result = await business.Save(LotTreatment);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }

            [HttpPut]
            public async Task<ActionResult> Put([FromBody] LotTreatmentDto LotTreatment)
            {
                if (LotTreatment == null)
                {
                    return BadRequest();
                }
                await business.Update(LotTreatment);
                return NoContent();
            }
        }
}
