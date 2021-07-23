using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Sessions = new HashSet<Session>();
        }

        public int VenueId { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public byte NumberOfCourts { get; protected set; }

        public virtual ICollection<Session> Sessions { get; protected set; }
    }
}
