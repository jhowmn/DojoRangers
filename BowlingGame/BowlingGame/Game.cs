using System;

namespace BowlingGame
{
    public class Game
    {
        private int[] throws = new int[21];
        private int currentIndex = 0;

        public void Roll(int pins)
        {
            throws[currentIndex] = pins;
            currentIndex++;
        }

        public int Score()
        {
            int score = 0;
            int firstInFrame = 0;

            for(int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    score += 10 + throws[firstInFrame + 1] + throws[firstInFrame + 2];
                    firstInFrame++;

                }
                else if (IsSpare(firstInFrame))
                {
                    score += 10 + throws[firstInFrame + 2];
                    firstInFrame += 2;
                }
                else
                {
                    score += throws[firstInFrame] + throws[firstInFrame + 1];
                    firstInFrame += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int firstInFrame)
        {
            return throws[firstInFrame] == 10;
        }

        private bool IsSpare(int i)
        {
            return throws[i] + throws[i + 1] == 10;
        }
    }
}