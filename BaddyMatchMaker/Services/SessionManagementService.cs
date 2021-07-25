using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Dto.RequestDto;
using BaddyMatchMaker.Helpers;
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

        public Round CreateNewRound(NextRoundRequestDto nextRoundRequest)
        {
            var numberOfCourts = nextRoundRequest.AvailableCourts.Count;
            var session = unitOfWork.SessionRepository
                .Get(s => s.SessionId == nextRoundRequest.SessionId, includeProperties: nameof(Session.Venue))
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

            var nextRound = session.Rounds.Count + 1;

            var roundSettings = new RoundSettings(nextRound, settings, nextRoundRequest.AvailableCourts);
            var matches = matchMakingService.CreateMatches(roundSettings).ToList();
            return new Round(session, matches, numberOfCourts, nextRound);
        }

        public Session CreateSession(SessionDto sessionDto)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionDto.SessionId);

            if (session != null)
            {
                throw new Exception("Session with same ID already exists.");
            }

            session = sessionDto.ToModel();
            session.StartSession();

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

            session.EndSession();
            unitOfWork.Commit();
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
