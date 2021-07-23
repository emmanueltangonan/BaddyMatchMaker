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
        private ISessionManagementService sessionManagementService;

        public RoundController(ISessionManagementService sessionManagementService)
        {
            this.sessionManagementService = sessionManagementService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("API Running...");
        }

        [HttpPost("[action]/{sessionId}")]
        public IActionResult GetNext(SettingDto settingsDto)
        {
            return new OkObjectResult(sessionManagementService.CreateNewRound(settingsDto));
        }

    }
}
