using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Strategies.MatchGrouping;
using BaddyMatchMaker.Strategies.PlayerPoolSelection;
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

        public Round CreateMatches(Setting settings, int numberOfCourts, Session session)
        {
            // get all players ordered by number of games played and sign in time
            var availablePlayers = unitOfWork.SessionPlayerRepository
                .Get(p => p.Active)
                .OrderBy(p => p.Player.PlayerMatches.Count)
                .OrderBy(p => p.SignInTime);

            var numberOfPlayersRequired = settings.SinglesMode
                ? PlayerPerMatch.Singles * numberOfCourts
                : PlayerPerMatch.Doubles * numberOfCourts;

            var playerPoolSelectionStrategy = playerPoolSelectionStrategyFactory.Create(settings);
            var playerPool = playerPoolSelectionStrategy.GetPlayerPool(availablePlayers, numberOfPlayersRequired);

            var matchGroupingStrategy = matchGroupingStrategyFactory.Create(settings);
            var matches = matchGroupingStrategy.GroupPlayers(playerPool).ToList();

            var round = new Round(session, matches, numberOfCourts);
            return round;
        }

    }

}
