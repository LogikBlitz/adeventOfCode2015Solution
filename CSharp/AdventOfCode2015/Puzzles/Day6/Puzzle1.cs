using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Puzzles.Day6
{
    internal class Puzzle1 : IPuzzle
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


        private const string TurnOn = "turn on";
        private const string TurnOff = "turn off";
        private const string Through = "through";
        private const string Toggle = "toggle";

        public string GetResult()
        {
            ValidateLogic();
            return $"Number of lights that are turned on: {SolvePuzzle(PuzzleInput.Data)}";
        }


        private int SolvePuzzle(string input)
        {
            var map = new Map(1000,1000);
            foreach (var word in GetWords(input))
            {
                foreach (var light in GetLightsForRange(word))
                {
                    map.AddLight(light);
                }
            }
            return map.GetNumberOfBrightLights();
        }

        private readonly Regex _regEx = new Regex("\\d+,\\d+", RegexOptions.Compiled);

        private IEnumerable<Light> GetLightsForRange(string inputRange)
        {
            var isOn = false;
            var isToggle = false;
            var trimValue = TurnOff;
            var input = inputRange.Trim();
            if (input.StartsWith(TurnOn))
            {
                isOn = true;
                trimValue = TurnOn;
            }else if (input.StartsWith(Toggle))
            {
                trimValue = Toggle;
                isToggle = true;
            }
            var matches =
                _regEx.Matches(inputRange.Replace(trimValue, string.Empty).Replace(Through, string.Empty).Trim());
            var p1 = matches[0].Value.Split(',');
            var p2 = matches[1].Value.Split(',');
            var startPoint = new Point(int.Parse(p1[0].Trim()), int.Parse(p1[1].Trim()));
            var endPoint = new Point(int.Parse(p2[0].Trim()), int.Parse(p2[1].Trim()));
            var x = startPoint.X;
            var y = startPoint.Y;
            while (x <= endPoint.X)
            {
                y = startPoint.Y;
                while (y <= endPoint.Y)
                {
                    var l = new Light(new Point(x, y)) {IsOn = isOn, Toggle = isToggle};
                    y++;
                    yield return l;
                }
                x++;
            }
        }

        private IEnumerable<string> GetWords(string input)
        {
            using (var reader = new StringReader(input))
            {
                string word = null;
                while ((word = reader.ReadLine()) != null)
                {
                    yield return word;
                }
            }
        }


        private void ValidateLogic()
        {
            var input = "turn on 0,0 through 999,999";
            var expectation = 1000*1000;
            var result = SolvePuzzle(input);
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            var sb = new StringBuilder();
            sb.AppendLine("turn on 0,0 through 999,999");
            sb.AppendLine("turn off 499,499 through 500,500");
            input = sb.ToString();
            expectation = 1000*1000 - 4;
            result = SolvePuzzle(input);
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}