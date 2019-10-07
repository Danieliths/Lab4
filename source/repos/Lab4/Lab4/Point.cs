using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public struct Point 
    {
        public Point(int x, int y)
        {
            row = x;
            column = y;
        }
        public readonly int row;
        public readonly int column;
    }
}
