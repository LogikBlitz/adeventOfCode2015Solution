﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Puzzles.Day6
{
    class Puzzle1 : IPuzzle
    {
        public int Day => 6;
        public int PuzzleIndex => 1;
        public string GetPurpose()
        {
            return @"--- Day 6: Probably a Fire Hazard ---

Because your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.

Furthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.

Lights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs. Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square. The lights all start turned off.

To defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.

For example:

turn on 0,0 through 999,999 would turn on (or leave on) every light.
toggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.
turn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.
After following the instructions, how many lights are lit?";
        }

        public string GetResult()
        {
            throw new NotImplementedException();
        }






        private void ValidateLogic()
        {
            //var input = "ugknbfddgicrmopn";
            //var expectation = 1;
            //var result = FindNiceWords(new[] { input }).Count();
            //if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            //input = "aaa";
            //expectation = 1;
            //result = FindNiceWords(new[] { input }).Count();
            //if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            //input = "jchzalrnumimnmhp";
            //expectation = 0;
            //result = FindNiceWords(new[] { input }).Count();
            //if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            //input = "haegwjzuvuyypxyu";
            //expectation = 0;
            //result = FindNiceWords(new[] { input }).Count();
            //if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            //input = "dvszwmarrgswjxmb";
            //expectation = 0;
            //result = FindNiceWords(new[] { input }).Count();
            //if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}
