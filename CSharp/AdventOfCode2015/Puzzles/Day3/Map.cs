using System.Collections.Generic;

namespace AdventOfCode2015.Puzzles.Day3
{
    internal class Map
    {

        public Map(IEnumerable<int> playerIds )
        {
            foreach (var playerId in playerIds)
            {
                _playerPositions.Add(playerId, new Coordinate(0,0));
            }
        }

        public Coordinate CoordinateForPlayer(int playerId)
        {
            return _playerPositions[playerId];
        }

        private readonly Dictionary<int, Dictionary<int, House>> _mapDictionary =
            new Dictionary<int, Dictionary<int, House>>();

        private readonly Dictionary<int, Coordinate> _playerPositions = new Dictionary<int, Coordinate>(); 

        private int _numberOfVisistedHouses = 0;

        public void PlayerMoveToCoordinate(Coordinate coordinate, int playerId)
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

            _playerPositions[playerId] = coordinate;
            CurrentCoordinate = coordinate;
        }

        public Coordinate CurrentCoordinate { get;  set; }

        public int NumberOfVisitedHouses()
        {
            return _numberOfVisistedHouses;
        }
    }
}