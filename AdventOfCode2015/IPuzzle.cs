using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    interface IPuzzle
    {
        int Day { get; }
        int PuzzleIndex { get; }
        string GetPurpose();

        string GetResult();
    }
}
