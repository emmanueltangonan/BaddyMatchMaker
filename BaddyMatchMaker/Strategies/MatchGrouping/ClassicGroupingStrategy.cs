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
    public class ClassicGroupingStrategy : IMatchGroupingStrategy
    {
        private readonly RoundSettings roundSettings;

        public ClassicGroupingStrategy(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        private int PlayersNeededPerMatch => roundSettings.PlayersNeededPerMatch;

        public IEnumerable<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            

            return null;
        }
    }
}
