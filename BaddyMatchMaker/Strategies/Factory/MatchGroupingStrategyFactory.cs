using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Strategies.MatchGrouping;
using System;

namespace BaddyMatchMaker.Strategies.Factory
{
    public class MatchGroupingStrategyFactory : IMatchGroupingStrategyFactory
    {
        public IMatchGroupingStrategy Create(RoundSettings roundSettings)
        {
            if (roundSettings.IgnoreSex)
            {
                return new IndiscriminateGrouping(roundSettings);
            }
            else
            {
                if (roundSettings.PrioritizeMixed && !roundSettings.SinglesMode)
                {
                    return new MixedDoublesPrioritizedGrouping();
                }

                return new ClassicGrouping();
            }
        }
    }

    public interface IMatchGroupingStrategyFactory
    {
        IMatchGroupingStrategy Create(RoundSettings roundSettings);
    }
}
