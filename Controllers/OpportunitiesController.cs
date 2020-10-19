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
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunitiesController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetOpportunities()
        {
            var opportunities = _opportunityService.GetOpportunities();
            var response = new ResponseDto(nameof(GetOpportunities), ResultadoResponse.Sucesso, opportunities);
            return Ok(response);
        }
    }
}