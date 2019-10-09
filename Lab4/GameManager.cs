using System;
using System.Collections.Generic;
using System.IO;
namespace Lab4
{
    enum Direction { Upp, Down, Right, Left, None }
    enum Color { Red, Blue, Gray, Yellow, Green }  
    enum GameState { SetUp, Playing, EndScreen, ExitGame}
    class GameManager
    {        
        public Player Player { get; set; }
        public Construkt[,] Map { get; set; }
        public List<GameObject> GameObject { get; set; }
        public List<GameObject> EventObject { get; set; }
        public GameState Gamestate { get; set; }
    }
}
