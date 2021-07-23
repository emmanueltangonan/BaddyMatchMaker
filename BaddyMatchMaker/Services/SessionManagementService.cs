using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Models.Dto;
using BaddyMatchMaker.Repository;
using System;

namespace BaddyMatchMaker.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private IUnitOfWork unitOfWork;

        public SessionManagementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Round CreateNewRound(SettingDto settingsDto)
        {
            throw new System.NotImplementedException();
        }

        public Session CreateSession(SessionDto sessionDto)
        {
            var  session = sessionDto.ToModel();
            unitOfWork.SessionRepository.Insert(session);
            unitOfWork.Commit();
            return session;
        }

        public void EndSession()
        {
            throw new System.NotImplementedException();
        }

        public void SignAllPlayersIn(SessionDto sessionDto)
        {
            var allPlayers = unitOfWork.PlayerRepository.Get();
            var session = unitOfWork.SessionRepository.GetById(sessionDto.SessionId);

            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            var signUpTimeDelay = 0;
            foreach (var player in allPlayers)
            {
                var sessionPlayer = new SessionPlayer(sessionDto.SessionId, player.PlayerId);
                sessionPlayer.SignIn(DateTime.Now.AddSeconds(signUpTimeDelay += 5).ToUniversalTime());
                session.SignInPlayer(sessionPlayer);
            }

            unitOfWork.Commit();
        }

        public SessionPlayer SignInPlayer(SessionPlayerDto sessionPlayerDto)
        {
            var sessionPlayer = sessionPlayerDto.ToModel();
            sessionPlayer.SignIn();

            var session = unitOfWork.SessionRepository.GetById(sessionPlayer.SessionId);

            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            session.SignInPlayer(sessionPlayer);
            unitOfWork.Commit();
            return sessionPlayer;
        }

        public void SignOutPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void SwapPlayers()
        {
            throw new System.NotImplementedException();
        }
    }
}
