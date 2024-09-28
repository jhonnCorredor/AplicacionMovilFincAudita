using Business.Interfaces.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Checklist")]
    [ApiController]
    public class ChecklistController : ControllerBase, IChecklistController
    {
        private readonly IChecklistBusiness business;

        public ChecklistController(IChecklistBusiness business)
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
        public async Task<ActionResult<ApiResponse<ChecklistDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ChecklistDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] ChecklistDto Checklist)
        {
            if (Checklist == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Checklist);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ChecklistDto Checklist)
        {
            if (Checklist == null)
            {
                return BadRequest();
            }
            await business.Update(Checklist);
            return NoContent();
        }
    }
}
