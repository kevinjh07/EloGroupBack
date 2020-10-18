using System.Threading.Tasks;
using EloGroupBack.Exceptions;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using EloGroupBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace EloGroupBack.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                var token = await _authService.LoginAsync(login);
                var response = new ResponseDto(nameof(Login), ResultadoResponse.Sucesso, new {token});
                return Ok(response);
            }
            catch (UnprocessableEntityException e)
            {
                var response = new ResponseDto(nameof(Login), ResultadoResponse.Sucesso, new {message = e.Message});
                return UnprocessableEntity(response);
            }
        }
    }
}