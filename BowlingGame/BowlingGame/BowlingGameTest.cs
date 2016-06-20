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
            game.Roll();
        }
    }
}
