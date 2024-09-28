using Business.Interfaces.Operational;
using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/ReviewTechnical")]
    [ApiController]
    public class ReviewTechnicalController : ControllerBase, IReviewTechnicalController
    {
        private readonly IReviewTechnicalBusiness business;

        public ReviewTechnicalController(IReviewTechnicalBusiness business)
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
        public async Task<ActionResult<ApiResponse<ReviewTechnicalDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReviewTechnicalDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] ReviewTechnicalDto ReviewTechnical)
        {
            if (ReviewTechnical == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(ReviewTechnical);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ReviewTechnicalDto ReviewTechnical)
        {
            if (ReviewTechnical == null)
            {
                return BadRequest();
            }
            await business.Update(ReviewTechnical);
            return NoContent();
        }
    }
}
