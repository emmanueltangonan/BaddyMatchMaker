using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using System;
using System.Linq;


namespace BaddyMatchMaker.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMatchMakingService matchMakingService;

        public SessionManagementService(IUnitOfWork unitOfWork, IMatchMakingService matchMakingService)
        {
            this.unitOfWork = unitOfWork;
            this.matchMakingService = matchMakingService;
        }

        public Round CreateNewRound(int sessionId, int numberOfCourts)
        {
            var session = unitOfWork.SessionRepository
                .Get(s => s.SessionId == sessionId, includeProperties: nameof(Session.Venue))
                .FirstOrDefault();

            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            if (session.Venue.NumberOfCourts < numberOfCourts)
            {
                throw new Exception("Requested number of courts exceeds venue's available courts.");
            }

            var settings = unitOfWork.SettingsRepository.GetById(session.ClubId);

            if (settings == null)
            {
                throw new Exception("Settings not found.");
            }

            var round = unitOfWork.RoundRepository
                .Get(r => r.RoundId == 1, includeProperties: nameof(Round.Matches))
                .FirstOrDefault();

            return round;
            //return matchMakingService.CreateMatches(settings, numberOfCourts, session);
        }

        public Session CreateSession(SessionDto sessionDto)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionDto.SessionId);

            if (session != null)
            {
                throw new Exception("Session with same ID already exists.");
            }

            session = sessionDto.ToModel();
            unitOfWork.SessionRepository.Insert(session);
            unitOfWork.Commit();
            return session;
        }

        public void EndSession(int sessionId)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionId);

            if (session == null)
            {
                throw new Exception("Session not found.");
            }
        }

        public void SignAllPlayersIn(int sessionId)
        {
            var allPlayers = unitOfWork.PlayerRepository.Get();
            var session = unitOfWork.SessionRepository.GetById(sessionId);

            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            var signUpTimeDelay = 0;
            foreach (var player in allPlayers)
            {
                var sessionPlayer = new SessionPlayer(sessionId, player.PlayerId);
                sessionPlayer.SignIn(DateTime.Now.AddSeconds(signUpTimeDelay += 5).ToUniversalTime());
                session.SignInPlayer(sessionPlayer);
            }

            unitOfWork.Commit();
        }

        public SessionPlayer SignInPlayer(int playerId, int sessionId)
        {
            var sessionPlayer = unitOfWork.SessionPlayerRepository
                .Get(sp => sp.PlayerId == playerId && sp.SessionId == sessionId)
                .FirstOrDefault();

            if (sessionPlayer != null)
            {
                throw new Exception("Player already signed in.");
            }

            sessionPlayer = new SessionPlayer(sessionId, playerId);
            sessionPlayer.SignIn();

            var session = unitOfWork.SessionRepository.GetById(sessionPlayer.SessionId);

            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            if (!session.Active)
            {
                throw new Exception("Session is inactive.");
            }

            session.SignInPlayer(sessionPlayer);
            unitOfWork.Commit();
            return sessionPlayer;
        }

        public void SignOutPlayer(int playerId, int sessionId)
        {
            var sessionPlayer = unitOfWork.SessionPlayerRepository
                .Get(sp => sp.PlayerId == playerId && sp.SessionId == sessionId)
                .FirstOrDefault();

            if (sessionPlayer == null)
            {
                throw new Exception("Player not signed in.");
            }

            sessionPlayer.SignOut();
            unitOfWork.Commit();
        }

        public void SwapPlayers(int roundId, int player1Id, int player2Id)
        {
            Round round = unitOfWork.RoundRepository.GetById(roundId);

            if (round == null)
            {
                throw new Exception("Round not found.");
            }

            round.SwapPlayers(player1Id, player2Id);
            unitOfWork.Commit();
        }
    }
}
