using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public class PlayerPoolSelectionStrategyFactory : IPlayerPoolSelectionStrategyFactory
    {
        public IPlayerPoolSelectionStrategy Create(Setting settings)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlayerPoolSelectionStrategyFactory
    {
        IPlayerPoolSelectionStrategy Create(Setting settings);
    }
}
