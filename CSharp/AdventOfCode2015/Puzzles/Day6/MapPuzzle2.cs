using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode2015.Puzzles.Day6
{
    internal class MapPuzzle2
    {
        private readonly Dictionary<int, Dictionary<int, Light>> _mapDictionary =
            new Dictionary<int, Dictionary<int, Light>>();

        public MapPuzzle2(int length, int height)
        {
            for (int i = 0; i < length; i++)
            {
                _mapDictionary.Add(i, new Dictionary<int, Light>());
                for (int j = 0; j < height; j++)
                {
                    _mapDictionary[i].Add(j, new Light(new Point(i, j)));
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
                yDirection[light.Coordinate.Y].Brightness = yDirection[light.Coordinate.Y].Brightness + 2;
            }
            else if (light.IsOn)
                yDirection[light.Coordinate.Y].Brightness++;
            else yDirection[light.Coordinate.Y].Brightness--;
        }

        public int GetBrightnessLevel()
        {
            var brightness = 0;
            foreach (var x in _mapDictionary.Keys)
            {
                var ydirection = _mapDictionary[x];
                foreach (var value in ydirection.Values)
                {
                    brightness += value.Brightness;
                }
            }
            return brightness;
        }
    }
}