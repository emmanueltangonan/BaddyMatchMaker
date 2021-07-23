using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Session> SessionRepository { get; }
        IRepository<Round> RoundRepository { get; }
        IRepository<Player> PlayerRepository { get; }

        void Commit();
    }
}
