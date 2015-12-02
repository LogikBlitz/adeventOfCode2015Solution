namespace AdventOfCode2015
{
    internal interface IPuzzle
    {
        /// <summary>
        /// The day in the month this Puzzle covers.
        /// Used for sorting so be careful when setting this
        /// </summary>
        int Day { get; }

        /// <summary>
        /// There re multiple puzzles every day.
        /// This value defines the order in which the puzzle
        /// resides within the day.
        /// Be carefull when setting this. It is used for sorting.
        /// </summary>
        int PuzzleIndex { get; }

        /// <summary>
        /// The the prupose for the puzzle. 
        /// Most of the time just copy the explanation from
        /// the puzzle webpage.
        /// Should be setup a bit with newlines and such to
        /// render nice in the console :-)
        /// </summary>
        /// <returns></returns>
        string GetPurpose();

        /// <summary>
        /// Get the result of the puzzle.
        /// Output should be a simple, yet precise definiton
        /// of the result.
        /// </summary>
        /// <returns></returns>
        string GetResult();
    }
}