using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Player : GameObject
    {
        public int NumberOfMoves { get; set; }
        public List<GameObject> Inventory { get; set; }        
        public Player()
        {
            Symbol = '@';            
            NumberOfMoves = 0;
            EntityColor = ConsoleColor.Red;
        }        
        public void CheckInteractAble(GameManager gameManager, int row, int column)
        {
            if (gameManager.Map[row,column] is IInteractAble interactableConstrukt)
            {
                interactableConstrukt.Interact(gameManager, gameManager.Map[row, column]); 
            }            
            foreach (var gameObject in gameManager.GameObject)
            {
                if (gameObject.Location.row == row && gameObject.Location.column == column && gameObject is IInteractAble interactAbleObject) 
                {
                    interactAbleObject.Interact(gameManager, gameObject);
                    break;
                }               
            }
        }
    }
}
