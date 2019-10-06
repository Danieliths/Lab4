using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public struct Point //värdetyp like int fast med två tal Point.row = x
    {
        public Point(int x, int y)
        {
            row = x;
            column = y;
        }
        public readonly int row; // Emil/johans kod, ´lär dig vad det gör eller ta bort det din noob
        public readonly int column;
    }
}
