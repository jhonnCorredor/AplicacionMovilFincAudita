using Business.Interfaces.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Alert")]
    [ApiController]
    public class AlertController : ControllerBase, IAlertController
    {
        private readonly IAlertBusiness business;

        public AlertController(IAlertBusiness business)
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
        public async Task<ActionResult<ApiResponse<AlertDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AlertDto>>>> GetAll()
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

        [HttpPost("Notifications")]
        public async Task<ActionResult<ApiResponse<IEnumerable<AlertDto>>>> GetByUser([FromBody] DataSelectDto Alert)
        {
            var result = await business.GetByUser(Alert);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlertDto Alert)
        {
            if (Alert == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Alert);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AlertDto Alert)
        {
            if (Alert == null)
            {
                return BadRequest();
            }
            await business.Update(Alert);
            return NoContent();
        }
    }
}
