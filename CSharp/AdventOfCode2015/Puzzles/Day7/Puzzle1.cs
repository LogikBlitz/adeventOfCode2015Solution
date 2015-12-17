using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace AdventOfCode2015.Puzzles.Day7
{
    class Puzzle1 : IPuzzle
    {
        public int Day => 7;
        public int PuzzleIndex => 1;
        public string GetPurpose()
        {
            throw new NotImplementedException();
        }

        public string GetResult()
        {
            throw new NotImplementedException();
        }

        private void SolvePuzzle(string input)
        {
            
        }
        private IEnumerable<string> GetLine(string input)
        {
            using (var reader = new StringReader(input))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }


        private Dictionary<string, int> _wires = new Dictionary<string, int>();
        
        
         
    }

    class CircuitGrammar
    {


        private static readonly Parser<string> BITWISE_AND = Parse.String("AND").Text();
        private static readonly Parser<string> LEFT_SHIFT = Parse.String("LSHIFT").Text();
        private static readonly Parser<string> IGHT_SHIFT = Parse.String("RSHIFT").Text();
        private static readonly Parser<string> NOT = Parse.String("NOT").Text();
        private static readonly Parser<string> OR = Parse.String("OR").Text();


    }

    class Signal
    {
        public int Value { get; }

        public Signal(int value)
        {
            Value = value;
        }
    }

    class Wire
    {
        public string Name { get; }

        public Wire(string name)
        {
            Name = name;
        }
    }

    class Gate
    {
        

    }

    class AndGate : Gate
    {
        

    }

}
