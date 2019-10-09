using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class MovementController
    {
        void ObjectMoveTo(GameManager gameManager, GameObject objectToMove, int row, int column)
        {
            gameManager.Player.CheckInteractAble(gameManager, objectToMove.Location.row + row, objectToMove.Location.column + column);
            if (gameManager.Map[objectToMove.Location.row + row, objectToMove.Location.column + column].CrossAble)
            {
                objectToMove.Location = new Point(objectToMove.Location.row + row, objectToMove.Location.column + column);
                gameManager.Player.NumberOfMoves += 1;
            }
        }
        public void ObjectMovment(GameManager gameManager, GameObject objectToMove, Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.Upp:
                    ObjectMoveTo(gameManager, objectToMove, 0, -1);
                    break;

                case Direction.Down:                    
                    ObjectMoveTo(gameManager, objectToMove, 0, +1);
                    break;

                case Direction.Right:                    
                    ObjectMoveTo(gameManager, objectToMove, +1, 0);
                    break;

                case Direction.Left:
                    ObjectMoveTo(gameManager, objectToMove, -1, 0);
                    break;                
                     
                default:
                    break;
            }            
        }
    }
}
