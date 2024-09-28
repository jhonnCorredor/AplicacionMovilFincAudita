using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;
using Business.Interfaces.Operational;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Lot")]
    [ApiController]
    public class LotController : ControllerBase, ILotController
    {
        private readonly ILotBusiness business;

        public LotController(ILotBusiness business)
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
        public async Task<ActionResult<ApiResponse<LotDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<LotDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] LotDto lot)
        {
            if (lot == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(lot);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LotDto lot)
        {
            if (lot == null)
            {
                return BadRequest();
            }
            await business.Update(lot);
            return NoContent();
        }
    }
}
