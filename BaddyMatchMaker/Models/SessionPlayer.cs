using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class SessionPlayer
    {
        public SessionPlayer(int sessionId, int playerId)
        {
            SessionId = sessionId;
            PlayerId = playerId;
        }

        public int SessionPlayerId { get; protected set; }
        public int SessionId { get; protected set; }
        public int PlayerId { get; protected set; }
        public DateTime SignUpTime { get; protected set; }
        public bool Active { get; protected set; }

        public virtual Player Player { get; protected set; }
        public virtual Session Session { get; protected set; }

        public void SignIn(DateTime? signInTime = null)
        {
            Active = true;
            SignUpTime = signInTime ?? DateTime.Now.ToUniversalTime();
        }
    }
}
