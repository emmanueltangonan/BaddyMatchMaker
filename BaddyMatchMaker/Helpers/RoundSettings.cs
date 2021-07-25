using BaddyMatchMaker.Models;
using System.Collections.Generic;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Helpers
{
    public class RoundSettings
    {
        private readonly Setting settings;
        private readonly List<int> availableCourts;

        public RoundSettings(int roundNumber, Setting settings, List<int> availableCourts)
        {
            RoundNumber = roundNumber;
            this.settings = settings;
            this.availableCourts = availableCourts;
        }

        public bool IgnoreSex => settings.IgnoreSex;
        public bool SinglesMode => settings.SinglesMode;
        public bool PrioritizeMixed => settings.PrioritizeMixed;
        public IReadOnlyCollection<int> AvailableCourts => availableCourts.AsReadOnly();

        public int RoundNumber { get; }

        public int RequiredPlayersCount => SinglesMode
            ? PlayerPerMatch.Singles * availableCourts.Count
            : PlayerPerMatch.Doubles * availableCourts.Count;
    }
}
