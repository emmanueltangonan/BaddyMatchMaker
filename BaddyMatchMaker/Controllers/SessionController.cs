using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BaddyMatchMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private ISessionManagementService sessionManagementService;

        public SessionController(ISessionManagementService sessionManagementService)
        {
            this.sessionManagementService = sessionManagementService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] SessionDto sessionDto)
        {
            var session = sessionManagementService.CreateSession(sessionDto);
            return new OkObjectResult(SessionDto.FromModel(session));
        }

        [HttpPost("[action]")]
        public IActionResult SignInPlayer([FromBody] SessionPlayerDto sessionPlayerDto)
        {
            var sessionPlayer = sessionManagementService.SignInPlayer(sessionPlayerDto);
            return new OkObjectResult(SessionPlayerDto.FromModel(sessionPlayer));
        }

        [HttpPost("[action]")]
        public IActionResult SignAllPlayersIn([FromBody] SessionDto sessionDto)
        {
            sessionManagementService.SignAllPlayersIn(sessionDto);
            return new OkResult();
        }
    }
}
