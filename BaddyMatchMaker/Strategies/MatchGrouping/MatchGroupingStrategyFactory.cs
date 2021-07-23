using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    public class MatchGroupingStrategyFactory : IMatchGroupingStrategyFactory
    {
        public IMatchGroupingStrategy Create(Setting settings)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMatchGroupingStrategyFactory
    {
        IMatchGroupingStrategy Create(Setting settings);
    }
}
