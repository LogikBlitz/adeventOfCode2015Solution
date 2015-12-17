using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2015
{
    internal class PuzzleRunner : IPuzzleRunner
    {
        private readonly List<Day> _orderedPuzzles;

        public PuzzleRunner(IEnumerable<IPuzzle> puzzles)
        {
            if (puzzles == null) throw new ArgumentNullException(nameof(puzzles));
            if (!puzzles.Any()) throw new ArgumentException("No puzzles provided", nameof(puzzles));

            var pList = puzzles.ToList().GroupBy(puzzle => puzzle.Day);

            var days = new List<Day>(25);
            foreach (var grouping in pList)
            {
                var groupedPuzzles = grouping.ToList();
                if (groupedPuzzles.Count > 2) throw new Exception("Too many puzzles for day:" + grouping.Key);
                var day = new Day(groupedPuzzles, grouping.Key);
                days.Add(day);
            }

            var orderedDays = days.OrderBy(day => day.DayIndex);

            _orderedPuzzles = orderedDays.ToList();
        }

        public void SolveInRange(int startDay, int endDay)
        {
            startDay = startDay - 1;
            endDay = endDay - 1;
            endDay = _orderedPuzzles.Count < endDay ? _orderedPuzzles.Count-1 : endDay;
            startDay = _orderedPuzzles.Count >= startDay ? startDay : _orderedPuzzles.Count - 1;
            startDay = startDay < 0 ? 0 : startDay;
            var index = startDay;

            while (index <= endDay)
            {
                var day = _orderedPuzzles.ElementAt(index++);
                foreach (var puzzle in day.Puzzles)
                {
                    ConsoleWriter.PrintPuzzle(puzzle);

                    Console.WriteLine("Press any key to go to the next puzzle");
                    Console.ReadLine();
                }
            }
        }

        public void SolveThisDay(int dayIndex)
        {
            if (dayIndex <= 0) throw new ArgumentException("unsupported day Index");
            SolveInRange(dayIndex, dayIndex);
        }

        public void SolveFromDay(int dayIndex)
        {
            SolveInRange(dayIndex, int.MaxValue);
        }

        public void SolveAll()
        {
            SolveFromDay(1);
        }
    }

    internal class Day
    {
        public ICollection<IPuzzle> Puzzles { get; }
        public int DayIndex { get; }

        public Day(ICollection<IPuzzle> solversFortheDay, int dayIndex)
        {
            Puzzles = solversFortheDay.OrderBy(puzzle => puzzle.PuzzleIndex).ToList();
            DayIndex = dayIndex;
        }
    }

    internal class ConsoleWriter
    {
        private const int Width = 80;
        private const int Height = 30;

        public static void PrintPuzzle(IPuzzle puzzle)
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            var builder = new StringBuilder();
            for (var i = 0; i < Width; i++)
            {
                builder.Append("#");
            }
            Console.WriteLine(builder);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(0, 1);
            Console.Write($"Day: {puzzle.Day}\t\t\t Puzzle Index #: {puzzle.PuzzleIndex} ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(builder);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Puzzle Intro:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(puzzle.GetPurpose());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(builder);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Puzzle Result:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(puzzle.GetResult());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(builder);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press CTRL+C to EXIT");
            Console.WriteLine("");
        }
    }
}