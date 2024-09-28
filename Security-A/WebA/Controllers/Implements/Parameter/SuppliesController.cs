using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Parameter;
using Business.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Supplies")]
    [ApiController]
    public class SuppliesController : ControllerBase, ISuppliesController
    {
        private readonly ISuppliesBusiness business;

        public SuppliesController(ISuppliesBusiness business)
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
        public async Task<ActionResult<ApiResponse<SuppliesDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<SuppliesDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] SuppliesDto Supplies)
        {
            if (Supplies == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Supplies);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SuppliesDto Supplies)
        {
            if (Supplies == null)
            {
                return BadRequest();
            }
            await business.Update(Supplies);
            return NoContent();
        }
    }
}
