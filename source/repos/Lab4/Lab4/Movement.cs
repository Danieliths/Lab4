using System.Collections.Generic;
using System.Text;

namespace Lab4
{
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
