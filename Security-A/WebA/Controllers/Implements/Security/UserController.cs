using Business.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserBusiness business;

        public UserController(IUserBusiness business)
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
        public async Task<ActionResult<ApiResponse<UserDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAll()
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

        [HttpPost("/login")]
        public async Task<ActionResult> Login(AuthenticationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Login(dto);
            if (result.IsNullOrEmpty())
            {
                return BadRequest("User no registrado");
            }
            return CreatedAtAction(nameof(Login), new { menu = result });
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(user);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await business.Update(user);
            return NoContent();
        }
    }
}
