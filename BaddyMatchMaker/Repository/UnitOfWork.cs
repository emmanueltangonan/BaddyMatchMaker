using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaddyMatchMakerContext dbContext;
        private IRepository<Session> sessionRepository;
        private IRepository<Round> roundRepository;
        private IRepository<Player> playerRepository;

        public UnitOfWork(BaddyMatchMakerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<Session> SessionRepository => sessionRepository ??= new Repository<Session>(dbContext);

        public IRepository<Round> RoundRepository => roundRepository ??= new Repository<Round>(dbContext);

        public IRepository<Player> PlayerRepository => playerRepository ??= new Repository<Player>(dbContext);

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
