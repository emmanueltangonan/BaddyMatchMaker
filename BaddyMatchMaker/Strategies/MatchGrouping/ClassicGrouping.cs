using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    /// <summary>
    /// Forms doubles matches: men's, women's and mixed doubles
    /// Prioritizes regular doubles over mixed doubles
    /// </summary>
    public class ClassicGrouping : IMatchGroupingStrategy
    {
        public ClassicGrouping()
        {

        }

        public IEnumerable<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            if (playerPool.Count % PlayerPerMatch.Doubles != 0)
            {
                throw new ArgumentException("Expected player count to be multiple of 4.");
            }

            return null;
        }
    }
}
