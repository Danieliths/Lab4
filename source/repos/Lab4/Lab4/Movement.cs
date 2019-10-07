using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    enum Direction { Upp,Down,Right,Left, None}
    class Input
    {
        public Direction DirectionInput(GameManager gameManager)
        {
            var direction = Direction.None;
            do
            {               
                Console.SetCursorPosition(gameManager.Player.Location.row,gameManager.Player.Location.column); // Silvertejp för att lösa att det skrivs ut en inmatad bokstav ner höger om spelare
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
                    return Direction.None; // adda eventuellt hjälpmedelande om man trycker fel
            }
            } while (direction == Direction.None);
        }
    }
    class Movement
    {
        public void ObjektMovment(GameManager gameManager, GameObjekt objektToMove, Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.Upp:
                    if (gameManager.Map[objektToMove.Location.row, objektToMove.Location.column - 1].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row, objektToMove.Location.column - 1);
                    }                    
                    break;
                case Direction.Down:
                    if (gameManager.Map[objektToMove.Location.row, objektToMove.Location.column + 1].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row, objektToMove.Location.column + 1);
                    }                   
                    break;
                case Direction.Right:
                    if (gameManager.Map[objektToMove.Location.row + 1, objektToMove.Location.column].CrossAble)
                    {
                        objektToMove.Location = new Point(objektToMove.Location.row + 1, objektToMove.Location.column);
                    }                    
                    break;
                case Direction.Left:
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
