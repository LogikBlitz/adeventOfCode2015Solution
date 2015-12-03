using System;

namespace AdventOfCode2015.Puzzles.Day3
{
    internal class Puzzle2 : IPuzzle
    {
        #region Implementation of IPuzzle

        /// <summary>
        ///     The day in the month this Puzzle covers.
        ///     Used for sorting so be careful when setting this
        /// </summary>
        public int Day => 3;

        /// <summary>
        ///     There re multiple puzzles every day.
        ///     This value defines the order in which the puzzle
        ///     resides within the day.
        ///     Be carefull when setting this. It is used for sorting.
        /// </summary>
        public int PuzzleIndex => 2;

        /// <summary>
        ///     The the prupose for the puzzle.
        ///     Most of the time just copy the explanation from
        ///     the puzzle webpage.
        ///     Should be setup a bit with newlines and such to
        ///     render nice in the console :-)
        /// </summary>
        /// <returns></returns>
        public string GetPurpose()
        {
            return
                @"The next year, to speed up the process, Santa creates a robot version of himself, Robo-Santa, to deliver presents with him.

Santa and Robo - Santa start at the same location(delivering two presents to the same starting house), then take turns moving based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.

This year, how many houses receive at least one present?

For example:

^ v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
^> v < now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
^ v ^ v ^ v ^ v ^ v now delivers presents to 11 houses, with Santa going one direction and Robo - Santa going the other.";
        }

        /// <summary>
        ///     Get the result of the puzzle.
        ///     Output should be a simple, yet precise definiton
        ///     of the result.
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
            var santId = 0;
            var roboSantaId = 1;
            var map = new Map(new[] { santId, roboSantaId });
            map.PlayerMoveToCoordinate(new Coordinate(0, 0), santId);
            map.PlayerMoveToCoordinate(new Coordinate(0,0),roboSantaId );
            var currentPlayer = santId;
            foreach (var c in chars)
            {
                var current = map.CoordinateForPlayer(currentPlayer);
                switch (c)
                {
                    case North:
                        map.PlayerMoveToCoordinate(new Coordinate(current.X, current.Y + 1), currentPlayer);

                        break;
                    case South:
                        map.PlayerMoveToCoordinate(new Coordinate(current.X, current.Y - 1), currentPlayer);
                        break;
                    case East:
                        map.PlayerMoveToCoordinate(new Coordinate(current.X + 1, current.Y), currentPlayer);
                        break;
                    case West:
                        map.PlayerMoveToCoordinate(new Coordinate(current.X - 1, current.Y), currentPlayer);
                        break;
                    default:
                        throw new Exception("Unknown char: " + c);
                }

                currentPlayer ^= 1;

            }
            return map.NumberOfVisitedHouses();
        }

        private void Validate()
        {
            var expectation = 3;
            var input = @"^v";
            var output = GetNumberOfVisitedHouses(input);
            if (expectation != output) throw new Exception($"Expected: {expectation} but got {output}");

            expectation = 3;
            input = @"^>v<";
            output = GetNumberOfVisitedHouses(input);
            if (expectation != output) throw new Exception($"Expected: {expectation} but got {output}");

            expectation = 11;
            input = @"^v^v^v^v^v";
            output = GetNumberOfVisitedHouses(input);
            if (expectation != output) throw new Exception($"Expected: {expectation} but got {output}");
        }

        #endregion
    }
}