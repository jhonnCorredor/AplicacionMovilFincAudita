using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ICountryController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<CountryDto>>>> GetAll();
        Task<ActionResult<ApiResponse<CountryDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] CountryDto country);
        Task<ActionResult> Put([FromBody] CountryDto country);
        Task<ActionResult> Delete(int id);
    }
}
