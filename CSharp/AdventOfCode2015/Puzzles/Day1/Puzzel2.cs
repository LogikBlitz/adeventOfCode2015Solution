using System;

namespace AdventOfCode2015.Puzzles.Day1
{
    internal class Puzzel2 : IPuzzle
    {
        private const int StartFloor = 0;
        private const char Increment = '(';
        private const char Decrement = ')';


        private int GetFloor(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(input, nameof(input));

            var chars = input.ToCharArray();
            var floor = StartFloor;
            for (var i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
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
                if (floor == -1)
                    return i + 1;
            }
            throw new Exception("Could not find the correct floor");
        }

        #region Implementation of IPuzzle<string,int>

        public int Day => 1;
        public int PuzzleIndex => 1;

        public string GetPurpose()
        {
            return
                "find the position of the first character that causes him to enter the basement (floor -1). \nThe first character in the instructions has position 1, the second character has position 2, and so on." +
                "\nWhat is the position of the character that causes Santa to first enter the basement?";
        }

        public string GetResult()
        {
            var position = Solve();
            return "Santa reached the basement the first time for character at position:\t\t" + position;
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