using System;
using System.Collections.Generic;
using System.IO;
namespace Lab4
{
    enum Direction { Upp, Down, Right, Left, None }
    enum Color { Red, Blue, Gray, Yellow, Green }  
    class GameManager
    {        
        public Player Player { get; set; }
        public Construkt[,] Map { get; set; }
        public List<GameObject> GameObject { get; set; }
        public List<GameObject> EventObject { get; set; }
    }
}
