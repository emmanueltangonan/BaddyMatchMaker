using BaddyMatchMaker.Models;
using System.Collections.Generic;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public interface IPlayerPoolSelectionStrategy
    {
        IEnumerable<SessionPlayer> GetPlayerPool(IEnumerable<SessionPlayer> availablePlayers, int numberOfPlayersRequired);
    }
}
