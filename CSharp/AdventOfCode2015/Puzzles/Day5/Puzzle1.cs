using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2015.Puzzles.Day5
{
    internal class Puzzle1 : IPuzzle
    {
        public int Day => 5;
        public int PuzzleIndex => 1;

        public string GetPurpose()
        {
            return @"--- Day 5: Doesn't He Have Intern-Elves For This? ---

Santa needs help figuring out which strings in his text file are naughty or nice.

A nice string is one with all of the following properties:

It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
For example:

ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), and none of the disallowed substrings.
aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
jchzalrnumimnmhp is naughty because it has no double letter.
haegwjzuvuyypxyu is naughty because it contains the string xy.
dvszwmarrgswjxmb is naughty because it contains only one vowel.
How many strings are nice?";
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
                if (ContainsOffendingWords(word)) continue;
                if (!WordHasDoubleLetter(word)) continue;
                if (!WordHasThreeVowels(word)) continue;
                yield return word;
            }
        }

        private readonly List<string> OffendingWords = new List<string>
        {
            "ab",
            "cd",
            "pq",
            "xy"
        };

        private bool ContainsOffendingWords(string word)
        {
            return OffendingWords.Any(word.Contains);
        }

        private bool WordHasDoubleLetter(string word)
        {
            var length = word.Length;
            for (var i = 0; i < length; i++)
            {
                var nextchar = i + 1;
                if (nextchar >= word.Length) return false;
                if (word[i].Equals(word[nextchar])) return true;
            }
            return false;
        }

        private readonly HashSet<char> _vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};

        private bool WordHasThreeVowels(string word)
        {
            return word.Count(c => _vowels.Contains(c)) >= 3;
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
            var input = "ugknbfddgicrmopn";
            var expectation = 1;
            var result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            input = "aaa";
            expectation = 1;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");

            input = "jchzalrnumimnmhp";
            expectation = 0;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            input = "haegwjzuvuyypxyu";
            expectation = 0;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
            input = "dvszwmarrgswjxmb";
            expectation = 0;
            result = FindNiceWords(new[] {input}).Count();
            if (expectation != result) throw new Exception($"Logic is flarred. Expected {expectation} got {result}");
        }
    }
}