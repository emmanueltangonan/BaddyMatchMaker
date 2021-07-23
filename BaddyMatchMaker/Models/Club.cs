using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Club
    {
        public Club()
        {
            Sessions = new HashSet<Session>();
        }

        public int ClubId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public virtual ICollection<Session> Sessions { get; protected set; }
    }
}
