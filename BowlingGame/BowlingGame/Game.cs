using System;

namespace BowlingGame
{
    public class Game
    {
        private int score = 0;

        public Game()
        {
        }

        public void Roll(int pontos)
        {
            score += pontos;
        }

        public int Score()
        {
            return score;
        }
    }
}