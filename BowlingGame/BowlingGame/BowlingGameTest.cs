using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame
{
    [TestClass]
    public class BowlingGameTest
    {
        private static Game game;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            game = new Game();
        }

        [TestMethod]
        public void CanRoll()
        {
            game.Roll(0);
        }

        [TestMethod]
        public void ThrowBall()
        {
            for(var i = 0; i < 20; i++)
                game.Roll(0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void IdiotsGame()
        {
            game.Roll(2);

            for (var i = 0; i < 19; i++)
                game.Roll(0);

            Assert.AreEqual(2, game.Score());
        }
    }
}
