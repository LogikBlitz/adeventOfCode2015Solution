using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Puzzles.Day2
{
    internal class Puzzle2 : IPuzzle
    {
        #region Implementation of IPuzzle

        public int Day => 2;
        public int PuzzleIndex => 1;

        public string GetPurpose()
        {
            return "The elves are also running low on ribbon. Ribbon is all the same width," +
                   "\nso they only have to worry about the length they need to order, which they would again like to be exact.\n" +
                   "The ribbon required to wrap a present is the shortest distance around its sides," +
                   "\n or the smallest perimeter of any one face. " +
                   "\nEach present also requires a bow made out of ribbon as well; " +
                   "\nthe feet of ribbon required for the perfect bow is equal to the cubic feet of volume" +
                   "\n of the present.Don't ask how they tie the bow, though; they'll never tell.";
        }

        public string GetResult()
        {
            ValidateLogic();
            var boxes = PuzzleInput.Puzzle1Boxes();
            var totalLenghtOfRibbonRquired = boxes.Sum(box => CalculateLengthOfRibbonToWrapTheBox(box));
            return "Total length of ribbon required is: " + totalLenghtOfRibbonRquired;
        }

        #endregion

        #region Private

        private static int CalculateLengthOfRibbonToWrapTheBox(Box box)
        {
            var orderedValues = new List<int> {box.Height, box.Length, box.Width}.OrderBy(i => i);
            const int limit = 2;
            var result = 0;
            for (var i = 0; i < limit; i++)
            {
                result += orderedValues.ElementAt(i) + orderedValues.ElementAt(i);
            }

            var bow = orderedValues.Aggregate(1, (x, y) => x*y);
            return result + bow;
        }


        private void ValidateLogic()
        {
            int expectation = 34;
            var result = CalculateLengthOfRibbonToWrapTheBox(new Box(2, 3, 4));
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            expectation = 14;
            result = CalculateLengthOfRibbonToWrapTheBox(new Box(1, 1, 10));
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }

        #endregion
    }
}