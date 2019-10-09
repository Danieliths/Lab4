using System;

namespace Lab4
{
    abstract class Entity
    {
        public char Symbol { get; protected set; }                
        public Point Location { get; set; }
        public ConsoleColor EntityColor { get; protected set; }
    }
}