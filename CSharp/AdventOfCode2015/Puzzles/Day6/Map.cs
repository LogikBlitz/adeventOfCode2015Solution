using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode2015.Puzzles.Day6
{
    internal class Map
    {
        private readonly Dictionary<int, Dictionary<int, Light>> _mapDictionary =
            new Dictionary<int, Dictionary<int, Light>>();

        public Map(int length, int height)
        {
            for (int i = 0; i < length; i++)
            {
                _mapDictionary.Add(i, new Dictionary<int, Light>() );
                for (int j = 0; j < height; j++)
                {
                    _mapDictionary[i].Add(j, new Light(new Point(i,j)));
                }
            }
        }

        public void AddLight(Light light)
        {
            if (!_mapDictionary.ContainsKey(light.Coordinate.X))
                _mapDictionary.Add(light.Coordinate.X, new Dictionary<int, Light>());

            var yDirection = _mapDictionary[light.Coordinate.X];
            if (light.Toggle)
            {
               yDirection[light.Coordinate.Y].IsOn = !yDirection[light.Coordinate.Y].IsOn;
            }
            else yDirection[light.Coordinate.Y] = light;
        }

        public int GetNumberOfBrightLights()
        {
            var numberOfBrightLights = 0;
            foreach (var x in _mapDictionary.Keys)
            {
                var ydirection = _mapDictionary[x];
                foreach (var value in ydirection.Values)
                {
                    numberOfBrightLights++;
                    if (!value.IsOn) numberOfBrightLights--;
                }
            }
            return numberOfBrightLights;
        }
    }
}