namespace AdventOfCode2015.Puzzles.Day3
{
    internal class House
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        public House(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public Coordinate Coordinate { get;}
        public int VisitationCount { get; private set; }

        public void IncrementVisitationCount()
        {
            VisitationCount++;
        }

        public void DecrementVisitaionCount()
        {
            VisitationCount--;
        }
    }
}