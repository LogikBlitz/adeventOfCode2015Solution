using System.Drawing;
using AdventOfCode2015.Puzzles.Day3;

namespace AdventOfCode2015.Puzzles.Day6
{
    internal class Light    
    {
        private int _brightness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        public Light(Point coordinate)
        {
            Coordinate = coordinate;
        }

        public Point Coordinate { get;}

        public bool IsOn { get; set; }

        public bool Toggle { get; set; }

        public int Brightness
        {
            get { return _brightness; }
            set
            {
                _brightness = value;
                if (_brightness < 0) _brightness = 0;
            }
        }

        //public int VisitationCount { get; private set; }

        //public void IncrementVisitationCount()
        //{
        //    VisitationCount++;
        //}

        //public void DecrementVisitaionCount()
        //{
        //    VisitationCount--;
        //}
    }
}