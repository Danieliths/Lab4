using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    enum Direction { Upp,Down,Right,Left}
    class Input
    {
        public Direction DirectionInput(GameManager gameManager)
        {
            return Direction.Right;
        }
    }
    class Movement
    {
        public void ObjektMovment(GameManager gameManager, GameObjekt objektToMove, Direction directionToMove)
        {            
            objektToMove.Location = new Point(objektToMove.Location.row + 1, objektToMove.Location.column);
        }
    }
}
