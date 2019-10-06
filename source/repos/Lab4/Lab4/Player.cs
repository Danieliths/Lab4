using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Player : GameObjekt// Interface
    {
        
        public int NumberOfMoves { get; set; }
        public List<GameObjekt> Inventory { get; set; }
        public Player()
        {
            Symbol = '@';            
            NumberOfMoves = 0;
        }
        

    }
}
