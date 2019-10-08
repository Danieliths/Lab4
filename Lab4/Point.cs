using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public struct Point 
    {
        public Point(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        public readonly int row;
        public readonly int column;
    }
}
