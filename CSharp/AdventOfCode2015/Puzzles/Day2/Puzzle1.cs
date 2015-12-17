using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Puzzles.Day2
{
    internal class Puzzle1 : IPuzzle
    {

        #region Implementation of IPuzzle

        public int Day => 2;
        public int PuzzleIndex => 1;

        public string GetPurpose()
        {
            return "---Day 2: I Was Told There Would Be No Math ---\n" +
                   "The elves are running low on wrapping paper, and so they need to submit an order for more. " +
                   "\nThey have a list of the dimensions (length l, width w," +
                   "and height h) of each present, \nand only want to order exactly as much as they need." +
                   "\nFortunately, every present is a box (a perfect right rectangular prism), " +
                   "\nwhich makes calculating the required wrapping paper for each gift a little easier: " +
                   "\nfind the surface area of the box, which is 2*l*w + 2*w*h + 2*h*l. " +
                   "\nThe elves also need a little extra paper for each present: the area of the smallest side.";
        }

        public string GetResult()
        {
            ValidateLogic();
            var boxes = PuzzleInput.Puzzle1Boxes();
            var totalArea = boxes.Sum(box => CalculateWrappingAreaForPackage(box));
            return "Total wrapping surface required is: " + totalArea;
        }

        #endregion

        #region Private

        private static int CalculateWrappingAreaForPackage(Box box)
        {
            var areas = new List<int>(4) {GetArea(box.Length, box.Width), GetArea(box.Width, box.Height), GetArea(box.Height, box.Length)};
            var smallest = areas.OrderBy(i => i).First();
            areas.Add(smallest>>1);
            if (areas.Count != 4) throw new Exception("Not the correct number of elements in list");

            return areas.Sum(i => i);
        }

        private static int GetArea(int lenght, int height)
        {
            return 2*lenght*height;
        }

        private void ValidateLogic()
        {
            const int expectation = 58;
            var result = CalculateWrappingAreaForPackage(new Box(2,3,4));
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }

        #endregion
    }
}