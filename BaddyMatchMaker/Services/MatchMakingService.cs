using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Strategies.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Services
{
    public class MatchMakingService : IMatchMakingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPlayerPoolSelectionStrategyFactory playerPoolSelectionStrategyFactory;
        private readonly IMatchGroupingStrategyFactory matchGroupingStrategyFactory;

        public MatchMakingService(
            IUnitOfWork unitOfWork, 
            IPlayerPoolSelectionStrategyFactory playerPoolSelectionStrategyFactory, 
            IMatchGroupingStrategyFactory matchGroupingStrategyFactory)
        {
            this.unitOfWork = unitOfWork;
            this.playerPoolSelectionStrategyFactory = playerPoolSelectionStrategyFactory;
            this.matchGroupingStrategyFactory = matchGroupingStrategyFactory;
        }

        public IEnumerable<Match> CreateMatches(RoundSettings roundSettings)
        {
            // get all players ordered by number of games played and sign in time
            var availablePlayers = unitOfWork.SessionPlayerRepository
                .Get(p => p.Active)
                .OrderBy(p => p.Player.PlayerMatches.Count)
                .OrderBy(p => p.SignInTime);

            // pool selection
            var playerPoolSelectionStrategy = playerPoolSelectionStrategyFactory.Create(roundSettings);
            var playerPool = playerPoolSelectionStrategy.GetPlayerPool(availablePlayers).ToList();

            if (!playerPool.Any())
            {
                throw new Exception("Not enough players to create a match.");
            }

            // court grouping and assignment
            var matchGroupingStrategy = matchGroupingStrategyFactory.Create(roundSettings);
            playerPool.Shuffle<SessionPlayer>();
            return matchGroupingStrategy.GroupPlayers(playerPool);
        }

    }

}
