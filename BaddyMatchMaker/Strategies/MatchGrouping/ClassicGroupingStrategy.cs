using BaddyMatchMaker.Helpers;
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
    public class ClassicGroupingStrategy : MatchGroupingStrategyBase, IMatchGroupingStrategy
    {
        public ClassicGroupingStrategy(RoundSettings roundSettings) : base(roundSettings)
        {
        }

        public List<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            if (playerPool.Count % PlayersNeededPerMatch != 0)
            {
                throw new ArgumentException($"Expected player count to be multiple of {PlayersNeededPerMatch}.");
            }



            return null;
        }
    }
}
