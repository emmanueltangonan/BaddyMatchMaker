using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    /// <summary>
    /// Gets an even number of males and females to be able to form valid matches
    /// Valid match = men's doubles, women's doubles and mixed doubles
    /// If the number of male or female players is odd, one player within the cutoff limit will have to be swapped
    /// with another player outside the cutoff following the 'least disruption' criteria ie. one that causes the least disruption to the queue
    /// Eg. Consider the list of players MMFFMMMM|MMMF... where | is the cutoff line
    /// Swapping M (8th pos) with F (12th) would give disruption index = 4; whereas changing F (4th) to M (9th), disruption index = 5; 
    /// So swapping M => F would cause less disruption and would be performed by this algorithm
    /// </summary>
    public class LeastDisruptionSelectionStrategy : IPlayerPoolSelectionStrategy
    {
        private readonly RoundSettings roundSettings;

        public LeastDisruptionSelectionStrategy(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        public IEnumerable<SessionPlayer> GetPlayerPool(IOrderedEnumerable<SessionPlayer> availablePlayers)
        {
            var playerPool = availablePlayers.Take(roundSettings.RequiredPlayersCount);

            if (playerPool.Count(p => p.Player.Sex == PlayerSex.Male) % 2 == 0)
            // if male count is even, then female count is even
            {
                return playerPool;
            }

            return GetPlayerPoolWithLeastDisruption(availablePlayers);
        }

        private IEnumerable<SessionPlayer> GetPlayerPoolWithLeastDisruption(IOrderedEnumerable<SessionPlayer> availablePlayers)
        {
            var requiredPlayersCount = roundSettings.RequiredPlayersCount;
            var lastItem = availablePlayers.Last();


        }
    }
}
