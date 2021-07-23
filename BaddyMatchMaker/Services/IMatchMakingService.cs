using BaddyMatchMaker.Models;

namespace BaddyMatchMaker.Services
{
    public interface IMatchMakingService
    {
        Round CreateMatches(Setting settings, int numberOfCourts, Session session);
    }
}