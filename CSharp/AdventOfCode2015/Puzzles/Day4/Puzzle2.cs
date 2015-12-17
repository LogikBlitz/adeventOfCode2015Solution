using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015.Puzzles.Day4
{
    internal class Puzzle2 : IPuzzle
    {
        private const string Input = "bgvyzdsv";
        public int Day => 4;
        public int PuzzleIndex => 2;

        public string GetPurpose()
        {
            return @"--- Day 4: The Ideal Stocking Stuffer ---

Same as puzzle one. but now with 6 leading zeros => 000000";
        }

        public string GetResult()
        {
            var result = SolvePuzzle(Input);
            _md5.Dispose();
            return $"The lowest number to produce leading zeros 000000 is: {result}";
        }


        public static int SolvePuzzle(string input)
        {
            var data = input;
            for (var i = 0; ; i++)
            {
                if (GetMd5Hex(data + i).StartsWith("000000")) return i;
            }

        }

        private static MD5 _md5 = MD5.Create();

        /// <summary>
        /// From http://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMd5Hex(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = _md5.ComputeHash(inputBytes);

            var encoded = BitConverter.ToString(hashBytes)
                       // without dashes
                       .Replace("-", string.Empty)
                       // make lowercase
                       .ToLower();
            return encoded;
        }


      
    }
}