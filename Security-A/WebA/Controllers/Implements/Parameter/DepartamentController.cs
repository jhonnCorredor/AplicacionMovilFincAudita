using Business.Interfaces.Parameter;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebA.Controllers.Interfaces.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Departament")]
    [ApiController]
    public class DepartamentController :ControllerBase, IDepartamentController
    {
        private readonly IDepartamentBusiness business;
        public DepartamentController(IDepartamentBusiness business)
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
        public async Task<ActionResult<ApiResponse<DepartamentDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<DepartamentDto>>>> GetAll()
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
        public async Task<ActionResult> Post([FromBody] DepartamentDto Departament)
        {
            if (Departament == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(Departament);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] DepartamentDto Departament)
        {
            if (Departament == null)
            {
                return BadRequest();
            }
            await business.Update(Departament);
            return NoContent();
        }
    }
}
