using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Puzzles.Day5
{
    internal class Puzzle2 : IPuzzle
    {
        public int Day => 5;
        public int PuzzleIndex => 2;

        public string GetPurpose()
        {
            return @"--- Part Two ---

Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice. None of the old rules apply, as they are all clearly ridiculous.

Now, a nice string is one with all of the following properties:

It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
For example:

qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice (qj) and a letter that repeats with exactly one letter between them (zxz).
xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
uurcxstgmygtbstg is naughty because it has a pair (tg) but no repeat with a single letter between them.
ieodomkazucvgmuy is naughty because it has a repeating letter with one between (odo), but no pair that appears twice.
How many strings are nice under these new rules?";
        }

        public string GetResult()
        {
            ValidateLogic();
            var numberOfNiceWords = FindNiceWords(GetWords(PuzzleInput.Data)).Count();
            return $"Number of nice words in input: {numberOfNiceWords}";
        }


        private IEnumerable<string> FindNiceWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                if (!WordHasPairedSubstrings(word)) continue;
                if (!WordContainsSameCharTwiceWithOnceCharSeparation(word)) continue;
                yield return word;
            }
        }

       

        private bool WordHasPairedSubstrings(string word)
        {
            var length = word.Length;
            for (var i = 0; i < length; i++)
            {
                var nextchar = i + 1;
                if (nextchar >= word.Length) return false;
                var subWord = $"{word[i]}{word[nextchar]}";
                if (Regex.Matches(word, subWord).Count < 2) continue;
                return true;
            }
            return false;
        }

        private bool WordContainsSameCharTwiceWithOnceCharSeparation(string word)
        {
            var length = word.Length;
            for (var i = 0; i < length; i++)
            {
                var nextchar = i + 2;
                if (nextchar >= word.Length) return false;
                if (!word[i].Equals(word[nextchar]))continue;
                return true;
            }
            return false;
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
            var input = "qjhvhtzxzqqjkmpb";
            var expectation = 1;
            var result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            input = "xxyxx";
            expectation = 1;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            input = "xxyyxxx";
            expectation = 1;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            input = "uurcxstgmygtbstg";
            expectation = 0;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            input = "ieodomkazucvgmuy";
            expectation = 0;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}