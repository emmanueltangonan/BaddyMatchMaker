using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System.Collections.Generic;

namespace BaddyMatchMaker.Services
{
    public interface IMatchMakingService
    {
        IEnumerable<Match> CreateMatches(RoundSettings roundSettings);
    }
}