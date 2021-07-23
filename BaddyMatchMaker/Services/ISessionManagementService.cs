using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;

namespace BaddyMatchMaker.Services
{
    public interface ISessionManagementService
    {
        Round CreateNewRound();
        Session CreateSession(SessionDto sessionDto);
        void EndSession();
        void SwapPlayers();
        SessionPlayer SignInPlayer(SessionPlayerDto sessionPlayerDto);
        void SignAllPlayersIn(SessionDto sessionDto);
        void SignOutPlayer();
    }
}