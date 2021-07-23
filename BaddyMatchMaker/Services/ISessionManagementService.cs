using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;

namespace BaddyMatchMaker.Services
{
    public interface ISessionManagementService
    {
        Round CreateNewRound(int sessionId, int numberOfCourts);
        Session CreateSession(SessionDto sessionDto);
        void EndSession(int sessionId);
        void SwapPlayers(int roundId, int player1Id, int player2Id);
        SessionPlayer SignInPlayer(int playerId, int sessionId);
        void SignAllPlayersIn(int sessionId);
        void SignOutPlayer(int playerId, int sessionId);
    }
}