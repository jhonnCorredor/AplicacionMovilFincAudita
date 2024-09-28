using Business.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase, IPersonController
    {
        protected readonly IPersonBusiness business;

        public PersonController(IPersonBusiness business)
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
        public async Task<ActionResult<ApiResponse<PersonDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PersonDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = business.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDto person)
        {
            if (person == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonDto person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            await business.Update(person);
            return NoContent();
        }
    }
}
