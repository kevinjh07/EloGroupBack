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
            var response = new ResponseDto {Metodo = nameof(PostLead)};

            try
            {
                _leadService.SaveLead(leadDto);
                response.Resutado = ResultadoResponse.Sucesso;
                return Created("", response);
            }
            catch (UnprocessableEntityException e)
            {
                response.Resutado = ResultadoResponse.Erro;
                response.Payload = new {message = e.Message};
                return UnprocessableEntity(response);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetLeads()
        {
            var leads = _leadService.GetLeads();
            var response = new ResponseDto(nameof(GetLeads), ResultadoResponse.Sucesso, leads);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PatchLeadStatus([FromRoute] int id, [FromBody] PatchLeadStatusDto leadDto)
        {
            var response = new ResponseDto {Metodo = nameof(PatchLeadStatus)};

            try
            {
                _leadService.UpdateStatus(id, leadDto.StatusId);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                response.Resutado = ResultadoResponse.Erro;
                return NotFound(response);
            }
            catch (UnprocessableEntityException e)
            {
                response.Resutado = ResultadoResponse.Erro;
                response.Payload = new {message = e.Message};
                return UnprocessableEntity(response);
            }
        }
    }
}