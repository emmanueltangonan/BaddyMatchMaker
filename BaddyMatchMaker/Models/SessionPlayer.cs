﻿using System;
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

        public int SessionPlayerId { get; set; }
        public int SessionId { get; set; }
        public int PlayerId { get; set; }
        public DateTime SignUpTime { get; set; }
        public bool Active { get; set; }

        public virtual Player Player { get; set; }
        public virtual Session Session { get; set; }

        public void SignIn(DateTime? signInTime = null)
        {
            Active = true;
            SignUpTime = signInTime ?? DateTime.Now.ToUniversalTime();
        }
    }
}
