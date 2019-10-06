using System;
using System.Collections.Generic;
using System.IO;
namespace Lab4
{
    class GameManager
    {        
        public Player Player { get; set; }
        public Construkt[,] Map { get; set; }
        public List<GameObjekt> GameObjekt { get; set; }
        public GameManager Instance { get; set; }        
    }
}
