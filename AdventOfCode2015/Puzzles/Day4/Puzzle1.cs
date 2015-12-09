using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015.Puzzles.Day4
{
    internal class Puzzle1 : IPuzzle
    {
        private const string Input = "bgvyzdsv";
        public int Day => 4;
        public int PuzzleIndex => 1;

        public string GetPurpose()
        {
            return @"--- Day 4: The Ideal Stocking Stuffer ---

Santa needs help mining some AdventCoins (very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.

To do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes. The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: 1, 2, 3, ...) that produces such a hash.

For example:

If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.
If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....";
        }

        public string GetResult()
        {
            ValidateLogic();
            var result = SolvePuzzle(Input);
            _md5.Dispose();
            return $"The lowest number to produce leading zeros 00000 is: {result}";
        }


        public static int SolvePuzzle(string input)
        {
            var data = input;
            for (var i = 0; ; i++)
            {
                if (GetMd5Hex(data + i).StartsWith("00000")) return i;
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


        private void ValidateLogic()
        {
            var input = "abcdef";
            var expectation = 609043;
            var result = SolvePuzzle(input);
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}