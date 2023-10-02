using Canguros.Api.Interfaces;
using Canguros.Api.Models.Requests;
using Canguros.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Canguros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CangurosController : ControllerBase
    {
        private readonly ICanguros _cangurosService;

        public CangurosController(ICanguros cangurosService)
        {
            _cangurosService = cangurosService;
        }

        [HttpGet]
        [Route("GetCangurosDistanceAsync")]
        public async Task<List<CangurosResponse>> GetCangurosDistanceAsync([FromQuery] CangurosRequest cangurosRequest)
        {
            return await _cangurosService.GetCangurosDistanceAsync(cangurosRequest);
        }
    }
}
