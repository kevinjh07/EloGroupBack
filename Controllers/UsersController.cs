using System.Threading.Tasks;
using EloGroupBack.Exceptions;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using EloGroupBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EloGroupBack.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostUser([FromBody] LoginDto userDto)
        {
            try
            {
                var result = await _userService.SaveUser(userDto);
                var response = new ResponseDto(nameof(PostUser), ResultadoResponse.Sucesso, new {token = result});
                return Ok(response);
            }
            catch (UnprocessableEntityException e)
            {
                var response = new ResponseDto(nameof(PostUser), ResultadoResponse.Erro, new {message = e.Message});
                return UnprocessableEntity(response);
            }
        }
    }
}