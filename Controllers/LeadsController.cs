using EloGroupBack.Exceptions;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using EloGroupBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EloGroupBack.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadsController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult PostLead([FromBody] LeadDto leadDto)
        {
            try
            {
                _leadService.SaveLead(leadDto);
                var result = new ResponseDto(nameof(PostLead), ResultadoResponse.Sucesso, null);
                return Created("", result);
            }
            catch (UnprocessableEntityException e)
            {
                var result = new ResponseDto(nameof(PostLead), ResultadoResponse.Erro, new {message = e.Message});
                return UnprocessableEntity(result);
            }
        }
    }
}