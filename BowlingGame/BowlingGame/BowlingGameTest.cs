using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game game;

        [TestInitialize]
        public void InitializeClass()
        {
            game = new Game();
        }

        [TestMethod]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void IdiotsGame()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void CalcSpare()
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(4);
            game.Roll(2);

            RollMany(16, 0);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void CalcStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);

            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(20, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollMany(int times, int pins)
        {
            for (var i = 0; i < times; i++)
                game.Roll(pins);
        }
    }
}
