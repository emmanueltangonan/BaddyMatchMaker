using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Helpers.Extensions;
using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    public class IndiscriminateGrouping : IMatchGroupingStrategy
    {
        private RoundSettings roundSettings;

        public IndiscriminateGrouping(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        private int PlayersNeededPerMatch => roundSettings.PlayersNeededPerMatch;

        public IEnumerable<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            if (playerPool.Count % PlayersNeededPerMatch != 0)
            {
                throw new ArgumentException("Expected player count to be multiple of 4.");
            }

            var availableCourts = new Queue<int>(roundSettings.AvailableCourts);
            var playerPoolOrderedBySkillLevel = new Queue<SessionPlayer>(playerPool.OrderByDescending(p => p.Player.Grade));

            var matchesToCreate = playerPool.Count / PlayersNeededPerMatch;
            if (matchesToCreate > availableCourts.Count)
            {
                throw new Exception("Player count exceeds expected number.");
            }

            for (var i = 0; i < matchesToCreate; i++)
            {
                var match = new Match {
                    CourtNumber = availableCourts.Dequeue(),
                    PlayerMatches = playerPoolOrderedBySkillLevel
                        .DequeueMultiple(PlayersNeededPerMatch)
                        .Select(p => new PlayerMatch { PlayerId = p.PlayerId })
                        .ToList()
                };

                yield return match;
            }
        }
    }
}
