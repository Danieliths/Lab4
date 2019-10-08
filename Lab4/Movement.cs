using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Movement
    {
        public void ObjectMovment(GameManager gameManager, GameObject objectToMove, Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.Upp:
                    gameManager.Player.CheckInteractAble(gameManager, objectToMove.Location.row, objectToMove.Location.column - 1);                    
                    if (gameManager.Map[objectToMove.Location.row, objectToMove.Location.column - 1].CrossAble)
                    {
                        objectToMove.Location = new Point(objectToMove.Location.row, objectToMove.Location.column - 1);
                    }                    
                    break;

                case Direction.Down:
                    gameManager.Player.CheckInteractAble(gameManager, objectToMove.Location.row, objectToMove.Location.column + 1);
                    if (gameManager.Map[objectToMove.Location.row, objectToMove.Location.column + 1].CrossAble)
                    {
                        objectToMove.Location = new Point(objectToMove.Location.row, objectToMove.Location.column + 1);
                    }                   
                    break;

                case Direction.Right:
                    gameManager.Player.CheckInteractAble(gameManager, objectToMove.Location.row + 1, objectToMove.Location.column);
                    if (gameManager.Map[objectToMove.Location.row + 1, objectToMove.Location.column].CrossAble)
                    {
                        objectToMove.Location = new Point(objectToMove.Location.row + 1, objectToMove.Location.column);
                    }                    
                    break;

                case Direction.Left:
                    gameManager.Player.CheckInteractAble(gameManager, objectToMove.Location.row - 1, objectToMove.Location.column);
                    if (gameManager.Map[objectToMove.Location.row - 1, objectToMove.Location.column].CrossAble)
                    {
                        objectToMove.Location = new Point(objectToMove.Location.row - 1, objectToMove.Location.column);
                    }                    
                    break;                

                default:
                    break;
            }            
        }
    }
}
