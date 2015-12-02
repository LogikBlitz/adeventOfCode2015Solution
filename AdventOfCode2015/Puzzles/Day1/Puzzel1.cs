using System;

namespace AdventOfCode2015.Puzzles.Day1
{
    internal class Puzzel1 : IPuzzle
    {
        private const int StartFloor = 0;
        private const char Increment = '(';
        private const char Decrement = ')';


        private int GetFloor(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(input, nameof(input));

            var chars = input.ToCharArray();
            var floor = StartFloor;
            foreach (var c in chars)
            {
                switch (c)
                {
                    case Increment:
                        floor++;
                        break;
                    case Decrement:
                        floor--;
                        break;
                    default:
                        throw new Exception("Unknown char: " + c);
                }
            }
            return floor;
        }

        #region Implementation of IPuzzle<string,int>

        public int Day => 1;
        public int PuzzleIndex => 1; 

        public string GetPurpose()
        {
            return "Santa is at (Floor 0) and the input contains ( ). a ( equals an INCREMENT of 1\n" +
                   ") equals a DECREMENT of 1.\n" +
                   "The purpose is to figure out at what floor santa is\n" +
                   "After processing a input string contain combinations of ().";
        }

        public string GetResult()
        {
            var floor = Solve();
            return "Santa is at Floor:\t\t" + floor;
        }

        #endregion

        #region Implementation of IPuzzle

        private int Solve()
        {
            return GetFloor(PuzzleInput.Data);
        }

        #endregion
    }
}