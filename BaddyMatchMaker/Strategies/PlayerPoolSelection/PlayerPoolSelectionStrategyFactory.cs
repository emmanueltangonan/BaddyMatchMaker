using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public class PlayerPoolSelectionStrategyFactory : IPlayerPoolSelectionStrategyFactory
    {
        public IPlayerPoolSelectionStrategy Create(Setting settings)
        {
            if (settings.IgnoreSex)
            {

            }
            return null;
        }
    }

    public interface IPlayerPoolSelectionStrategyFactory
    {
        IPlayerPoolSelectionStrategy Create(Setting settings);
    }
}
