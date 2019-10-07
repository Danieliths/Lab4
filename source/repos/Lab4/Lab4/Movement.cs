using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
   class Input
    {
        public Direction DirectionInput(GameManager gameManager)
        {
            var direction = Direction.None;
            do
            {               
                Console.SetCursorPosition(gameManager.Player.Location.row,gameManager.Player.Location.column);
            switch (Console.ReadKey().KeyChar)
            {
                case 'w':
                    return Direction.Upp;
                                       
                case 's':
                    return Direction.Down;
                    
                case 'd':                
                    return Direction.Right;

                case 'a':
                    return Direction.Left;
                    
                default:                    
                    return Direction.None;
            }
            } while (direction == Direction.None);
        } // adda eventuellt hjälpmedelande om man trycker fel för None
    }
    class Movement
    {
        public void ObjektMovment(GameManager gameManager, GameObjekt objektToMove, Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.Upp:
                    gameManager.Player.CheckInteractAble(gameManager, objektToMove.Location.row, objektToMove.Location.column - 1);                    
                    if (gameManager.Map[objektToMove.Location.row, objektToMove.Location.column - 1].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row, objektToMove.Location.column - 1);
                    }                    
                    break;

                case Direction.Down:
                    gameManager.Player.CheckInteractAble(gameManager, objektToMove.Location.row, objektToMove.Location.column + 1);
                    if (gameManager.Map[objektToMove.Location.row, objektToMove.Location.column + 1].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row, objektToMove.Location.column + 1);
                    }                   
                    break;

                case Direction.Right:
                    gameManager.Player.CheckInteractAble(gameManager, objektToMove.Location.row + 1, objektToMove.Location.column);
                    if (gameManager.Map[objektToMove.Location.row + 1, objektToMove.Location.column].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row + 1, objektToMove.Location.column);
                    }                    
                    break;

                case Direction.Left:
                    gameManager.Player.CheckInteractAble(gameManager, objektToMove.Location.row - 1, objektToMove.Location.column);
                    if (gameManager.Map[objektToMove.Location.row - 1, objektToMove.Location.column].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row - 1, objektToMove.Location.column);
                    }                    
                    break;                

                default:
                    break;
            }            
        }
    }
}
