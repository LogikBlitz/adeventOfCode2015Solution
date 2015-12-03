using System;

namespace AdventOfCode2015.Puzzles.Day3
{
    internal class Puzzle1 : IPuzzle
    {
        #region Implementation of IPuzzle

        /// <summary>
        /// The day in the month this Puzzle covers.
        /// Used for sorting so be careful when setting this
        /// </summary>
        public int Day => 3;

        /// <summary>
        /// There re multiple puzzles every day.
        /// This value defines the order in which the puzzle
        /// resides within the day.
        /// Be carefull when setting this. It is used for sorting.
        /// </summary>
        public int PuzzleIndex => 1;

        /// <summary>
        /// The the prupose for the puzzle. 
        /// Most of the time just copy the explanation from
        /// the puzzle webpage.
        /// Should be setup a bit with newlines and such to
        /// render nice in the console :-)
        /// </summary>
        /// <returns></returns>
        public string GetPurpose()
        {
            return "--- Day 3: Perfectly Spherical Houses in a Vacuum ---" +
                   "Santa is delivering presents to an infinite two - dimensional grid of houses." +
                   "He begins by delivering a present to the house at his starting location, and then an elf at the North Pole calls him via radio and tells him where to move next.Moves" +
                   "are always exactly one house to the north(^), south(v), east(>), or west (<).After each move, he delivers another present to the house at his new location." +
                   "However, the elf back at the north pole has had a little too much eggnog, and so his directions are a little off, and Santa ends up visiting some houses more than " +
                   "once.How many houses receive at least one present ?" +
                   "For example:" +
                   "> delivers presents to 2 houses: one at the starting location, and one to the east." +
                   "^> v < delivers presents to 4 houses in a square, including twice to the house at his starting / ending location." +
                   "^ v ^ v ^ v ^ v ^ v delivers a bunch of presents to some very lucky children at only 2 houses.";
        }

        /// <summary>
        /// Get the result of the puzzle.
        /// Output should be a simple, yet precise definiton
        /// of the result.
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            Validate();
            var numberOfVisistedHouses = GetNumberOfVisitedHouses(PuzzleInput.PuzzleData);
            return $"Number of houses Santa visited: {numberOfVisistedHouses}";
        }

        #endregion

        private const char North = '^';
        private const char South = 'v';
        private const char East = '>';
        private const char West = '<';

        #region private methods

        private int GetNumberOfVisitedHouses(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(input, nameof(input));

            var chars = input.ToCharArray();
            var map = new Map();
            map.SantaArrivedAtCoordinate(new Coordinate(0, 0));
            foreach (var c in chars)
            {
                Coordinate current;
                switch (c)
                {
                    case North:
                        current = map.CurrentCoordinate;
                        map.SantaArrivedAtCoordinate(new Coordinate(current.X, current.Y + 1));

                        break;
                    case South:
                        current = map.CurrentCoordinate;
                        map.SantaArrivedAtCoordinate(new Coordinate(current.X, current.Y - 1));
                        break;
                    case East:
                        current = map.CurrentCoordinate;
                        map.SantaArrivedAtCoordinate(new Coordinate(current.X + 1, current.Y));
                        break;
                    case West:
                        current = map.CurrentCoordinate;
                        map.SantaArrivedAtCoordinate(new Coordinate(current.X - 1, current.Y));
                        break;
                    default:
                        throw new Exception("Unknown char: " + c);
                }
            }
            return map.NumberOfVisitedHouses();
        }

        private void Validate()
        {
            var expectation = 4;
            var input = @"^>v<";
            var output = GetNumberOfVisitedHouses(input);
            if (expectation != output) throw new Exception($"Expected: {expectation} but got {output}");

            expectation = 2;
            input = @"^v^v^v^v^v";
            output = GetNumberOfVisitedHouses(input);
            if (expectation != output) throw new Exception($"Expected: {expectation} but got {output}");
        }

        #endregion
    }
}