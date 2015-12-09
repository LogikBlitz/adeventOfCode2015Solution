using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using AdventOfCode2015.BootStrap;
using Autofac;

namespace AdventOfCode2015
{
    internal class Program
    {
        private static bool _run;

        private static void Main(string[] args)
        {

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            var runner = DependencyResolver.Instance.Container.Resolve<IPuzzleRunner>();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the AdventOfCode puzzle solver.");
            Console.WriteLine("Exit by pressing CTRL+C at any time.");
            Console.WriteLine("");
            Console.WriteLine("Please select what you want to do!");

            _run = true;
            while (_run)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Solve Puzzles for a specific day.\t\t Press 1");
                Console.WriteLine("- Solve Puzzles for a specific range .\t\t Press 2");
                Console.WriteLine("- Solve All puzzles from a specific day.\t Press 3");
                Console.WriteLine("- Solve All puzzle.\t\t\t\t Press 4");

                var key = Console.ReadLine();
                var parsed = 0;
                int.TryParse(key, out parsed);

                switch (parsed)
                {
                    case 0:
                        Console.WriteLine("Your input is invalid.Please try again.");
                        break;
                    case 1:
                        Console.WriteLine("Input a number between 1-25 symbolizing the christmas days in December");
                        var day = Console.ReadLine();
                        var dayIndex = 1;
                        int.TryParse(day, out dayIndex);
                        if (dayIndex < 1 || dayIndex > 25)
                        {
                            Console.WriteLine("Input out of range. Please try again");
                            break;
                        }
                        runner.SolveThisDay(dayIndex);
                        break;
                    case 2:
                        Console.WriteLine("Input a number between 1-25 = startIndex");
                        var start = Console.ReadLine();
                        Console.WriteLine("Input a number between 1-25 = endIndex");
                        var end = Console.ReadLine();
                        var startIndex = 1;
                        var endIndex = 25;
                        int.TryParse(start, out startIndex);
                        int.TryParse(end, out endIndex);
                        if (startIndex < 1 || endIndex > 25)
                        {
                            Console.WriteLine("Input out of range. Please try again");
                            break;
                        }
                        runner.SolveInRange(startIndex, endIndex);
                        break;
                    case 3:
                        Console.WriteLine("Input a number between 1-25 symbolizing the christmas days in December");

                        var dayInput = Console.ReadLine();
                        var dayInputIndex = 1;
                        int.TryParse(dayInput, out dayInputIndex);
                        if (dayInputIndex < 1 || dayInputIndex > 25)
                        {
                            Console.WriteLine("Input out of range. Please try again");
                            break;
                        }
                        runner.SolveFromDay(dayInputIndex);
                        break;
                    case 4:
                        Console.WriteLine("Solving all puzzeles currently available");
                        Thread.Sleep(2000);
                        runner.SolveAll();
                        break;
                    default:
                        Console.WriteLine("Input cannot be parsed. Please try again");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("No more puzzles. Press any key to try again or CTRL+C to exit");
                Console.ReadLine();
                Console.Clear();
            }

            Console.ReadLine();
        }

        /// <summary>
        ///     Event handler for ^C key press
        /// </summary>
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Unfortunately, due to a bug in .NET Framework v4.0.30319 you can't debug this 
            // because Visual Studio 2010 gives a "No Source Available" error. 
            // http://connect.microsoft.com/VisualStudio/feedback/details/524889/debugging-c-console-application-that-handles-console-cancelkeypress-is-broken-in-net-4-0
            Console.WriteLine("{0} hit, quitting...", e.SpecialKey);
            _run = false;

            e.Cancel = true; // Set this to true to keep the process from quitting immediately
            Thread.Sleep(1200);
            Environment.Exit(0);
        }

        private static void TestMD5()
        {
            using (var md5 = MD5.Create())
            {
                string input = "0000";
                string output = "ABC";

                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                //byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                foreach (byte t in inputBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                var str = sb.ToString();
            }
        }
    }
}