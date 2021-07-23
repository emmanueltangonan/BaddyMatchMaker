using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Strategies.MatchGrouping;
using BaddyMatchMaker.Strategies.PlayerPoolSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Round CreateMatches(Setting settings, int numberOfCourts, Session session)
        {
            var playerPoolSelectionStrategy = playerPoolSelectionStrategyFactory.Create(settings);
            var matchGroupingStrategy = matchGroupingStrategyFactory.Create(settings);

            var availablePlayer = unitOfWork.SessionPlayerRepository
                .Get(p => p.Active)
                .OrderBy(p => p.Player.PlayerMatches.Count)
                .OrderBy(p => p.SignUpTime);

            return null;
        }

    }



}
