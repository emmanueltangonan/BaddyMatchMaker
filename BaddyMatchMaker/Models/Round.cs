using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Round
    {
        public Round()
        {
            Matches = new HashSet<Match>();
        }

        public int RoundId { get; set; }
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourtsAvailable { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

        private Match FindPlayerMatch(int playerId)
        {
            var match = Matches.FirstOrDefault(m => m.PlayerMatches.Select(pm => pm.PlayerId).Contains(playerId));
            if (match == null)
            {
                throw new Exception("Player not found.");
            }

            return match;
        }

        public void SwapPlayers(int player1Id, int player2Id)
        {
            var player1Match = FindPlayerMatch(player1Id);
            var player2Match = FindPlayerMatch(player2Id);

            if (player1Match.MatchId == player2Match.MatchId)
            {
                throw new Exception("Players in the same match.");
            }

            // remove player1 from original match then add to player2's original match
            var player1 = player1Match.PlayerMatches.First(pm => pm.PlayerId == player1Id);
            player1Match.PlayerMatches.Remove(player1);
            player2Match.PlayerMatches.Add(player1);

            // remove player2 from original match then add to player1's original match
            var player2 = player2Match.PlayerMatches.First(pm => pm.PlayerId == player2Id);
            player2Match.PlayerMatches.Remove(player2);
            player1Match.PlayerMatches.Add(player2);
        }

    }
}
