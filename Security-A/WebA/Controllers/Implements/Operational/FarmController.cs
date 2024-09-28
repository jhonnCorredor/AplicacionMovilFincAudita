using Business.Interfaces.Operational;
using Entity.Dto;
using Entity.Dto.Operational;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Farm")]
    [ApiController]
    public class FarmController : ControllerBase, IFarmController
    {
        private readonly IFarmBusiness business;

        public FarmController(IFarmBusiness business)
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
        public async Task<ActionResult<ApiResponse<FarmDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<FarmDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] FarmDto farm)
        {
            if (farm == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(farm);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FarmDto farm)
        {
            if (farm == null)
            {
                return BadRequest();
            }
            await business.Update(farm);
            return NoContent();
        }
    }
}
