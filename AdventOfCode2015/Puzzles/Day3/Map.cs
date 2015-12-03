using System.Collections.Generic;

namespace AdventOfCode2015.Puzzles.Day3
{
    internal class Map
    {
        private readonly Dictionary<int, Dictionary<int, House>> _mapDictionary =
            new Dictionary<int, Dictionary<int, House>>();

        private int _numberOfVisistedHouses = 0;

        public void SantaArrivedAtCoordinate(Coordinate coordinate)
        {
            if (!_mapDictionary.ContainsKey(coordinate.X))
                _mapDictionary.Add(coordinate.X, new Dictionary<int, House>());


            var yDirection = _mapDictionary[coordinate.X];
            if (!yDirection.ContainsKey(coordinate.Y))
            {
                yDirection.Add(coordinate.Y, new House(coordinate));
                _numberOfVisistedHouses++;
            }
            yDirection[coordinate.Y].IncrementVisitationCount();

            CurrentCoordinate = coordinate;
        }

        public Coordinate CurrentCoordinate { get; private set; }

        public int NumberOfVisitedHouses()
        {
            return _numberOfVisistedHouses;
        }
    }
}