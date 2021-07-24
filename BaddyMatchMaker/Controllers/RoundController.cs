using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaddyMatchMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly ISessionManagementService sessionManagementService;

        public RoundController(ISessionManagementService sessionManagementService)
        {
            this.sessionManagementService = sessionManagementService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var round = sessionManagementService.CreateNewRound(2, 6);
            return new OkObjectResult("API Running...");
        }

        [HttpPost("[action]/{sessionId}/{numberOfCourts}")]
        public IActionResult GetNext(int sessionId, int numberOfCourts)
        {
            return new OkObjectResult(sessionManagementService.CreateNewRound(sessionId, numberOfCourts));
        }

    }
}
