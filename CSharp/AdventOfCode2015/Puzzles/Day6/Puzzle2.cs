using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Puzzles.Day6
{
    internal class Puzzle2 : IPuzzle
    {
        public int Day => 6;
        public int PuzzleIndex => 2;

        public string GetPurpose()
        {
            return @"--- Part Two ---

You just finish implementing your winning light pattern when you realize you mistranslated Santa's message from Ancient Nordic Elvish.

The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more. The lights all start at zero.

The phrase turn on actually means that you should increase the brightness of those lights by 1.

The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.

The phrase toggle actually means that you should increase the brightness of those lights by 2.

What is the total brightness of all lights combined after following Santa's instructions?

For example:

turn on 0,0 through 0,0 would increase the total brightness by 1.
toggle 0,0 through 999,999 would increase the total brightness by 2000000.";
        }


        private const string TurnOn = "turn on";
        private const string TurnOff = "turn off";
        private const string Through = "through";
        private const string Toggle = "toggle";

        public string GetResult()
        {
            ValidateLogic();
            return $"Brightness Level for all lights: {SolvePuzzle(PuzzleInput.Data)}";
        }


        private int SolvePuzzle(string input)
        {
            var map = new MapPuzzle2(1000,1000);
            foreach (var word in GetWords(input))
            {
                foreach (var light in GetLightsForRange(word))
                {
                    map.AddLight(light);
                }
            }
            return map.GetBrightnessLevel();
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
            var input = "turn on 0,0 through 0,0";
            var expectation = 1;
            var result = SolvePuzzle(input);
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            input = "toggle 0,0 through 999,999";
            expectation = 2000000;
            result = SolvePuzzle(input);
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}