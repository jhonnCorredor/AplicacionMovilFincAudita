using Business.Interfaces.Operational;
using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Qualification")]
    [ApiController]
    public class QualificationController : ControllerBase, IQualificationController
    {
        private readonly IQualificationBusiness business;

        public QualificationController(IQualificationBusiness business)
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
        public async Task<ActionResult<ApiResponse<QualificationDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<QualificationDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] QualificationDto Qualification)
        {
            if (Qualification == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Qualification);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] QualificationDto Qualification)
        {
            if (Qualification == null)
            {
                return BadRequest();
            }
            await business.Update(Qualification);
            return NoContent();
        }
    }
}
