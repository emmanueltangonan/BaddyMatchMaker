﻿using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Strategies.PlayerPoolSelection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMakerTests.Strategies
{
    [TestClass]
    public class LeastDisruptionSelectionStrategyTests
    {

        [TestMethod]
        public void GetPlayerPool_SwapsPlayerCausingLeastDisruption()
        {
            var sessionPlayers = new List<SessionPlayer> {
                new SessionPlayer { PlayerId = 1, Player = new Player { Sex = PlayerSex.Male } },
                new SessionPlayer { PlayerId = 2, Player = new Player { Sex = PlayerSex.Male } },
                new SessionPlayer { PlayerId = 3, Player = new Player { Sex = PlayerSex.Female } },
                new SessionPlayer { PlayerId = 4, Player = new Player { Sex = PlayerSex.Male } },
                //-------------------------- cut off --------------------------------------
                new SessionPlayer { PlayerId = 5, Player = new Player { Sex = PlayerSex.Male } },
                new SessionPlayer { PlayerId = 6, Player = new Player { Sex = PlayerSex.Male } },
                new SessionPlayer { PlayerId = 7, Player = new Player { Sex = PlayerSex.Male } },
                new SessionPlayer { PlayerId = 8, Player = new Player { Sex = PlayerSex.Female } },
            };

            var roundSetting = new RoundSettings(1, new Setting(), new[] { 1 }.ToList());
            var selection = new LeastDisruptionSelectionStrategy(roundSetting);

            var playerPool = selection.GetPlayerPool(sessionPlayers.OrderBy(p => p.PlayerId));
            Assert.AreEqual(4, playerPool.Count());
            Assert.IsTrue(playerPool.Any() && playerPool.All(p => p.Player.Sex == PlayerSex.Male));
            Assert.IsNull(playerPool.FirstOrDefault(p => p.PlayerId == 3)); // female player 3 should be removed
            Assert.IsNotNull(playerPool.FirstOrDefault(p => p.PlayerId == 5)); // and swapped with male player 5
        }
    }
}
