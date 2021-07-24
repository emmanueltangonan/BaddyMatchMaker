using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    public interface IMatchGroupingStrategy
    {
        IEnumerable<Match> GroupPlayers(IEnumerable<SessionPlayer> players);
    }
}
