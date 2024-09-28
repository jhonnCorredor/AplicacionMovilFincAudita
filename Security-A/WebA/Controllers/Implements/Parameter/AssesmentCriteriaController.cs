using Business.Interfaces.Parameter;
using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Parameter;


namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/AssesmentCriteria")]
    [ApiController]
    public class AssesmentCriteriaController : ControllerBase, IAssesmentCriteriaController
    {
        private readonly IAssesmentCriteriaBusiness business;

        public AssesmentCriteriaController(IAssesmentCriteriaBusiness business)
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
        public async Task<ActionResult<ApiResponse<AssesmentCriteriaDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AssesmentCriteriaDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] AssesmentCriteriaDto AssesmentCriteria)
        {
            if (AssesmentCriteria == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(AssesmentCriteria);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AssesmentCriteriaDto AssesmentCriteria)
        {
            if (AssesmentCriteria == null)
            {
                return BadRequest();
            }
            await business.Update(AssesmentCriteria);
            return NoContent();
        }
    }
}
