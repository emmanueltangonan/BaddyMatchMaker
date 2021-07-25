using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public class IndiscriminateSelectionStrategy : IPlayerPoolSelectionStrategy
    {
        private readonly RoundSettings roundSettings;

        public IndiscriminateSelectionStrategy(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        public IEnumerable<SessionPlayer> GetPlayerPool(IOrderedEnumerable<SessionPlayer> availablePlayers)
        {
            var requiredPlayersCount = roundSettings.RequiredPlayersCount;
            var playerPool = availablePlayers.Take(requiredPlayersCount).ToList();

            if (playerPool.Count < requiredPlayersCount)
            {
                if (playerPool.Count % 2 == 0) 
                {
                    return playerPool;
                }

                return playerPool.Take(playerPool.Count - 1);
            }

            return playerPool;
        }
    }
}
