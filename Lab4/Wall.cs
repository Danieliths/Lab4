using System;

namespace Lab4
{
    class Wall : Construkt
    {
        public Wall(Point location)
        {
            Symbol = '#';
            Revealed = false;
            CrossAble = false;
            Location = location;
            EntityColor = ConsoleColor.Gray;
        }
    }
}