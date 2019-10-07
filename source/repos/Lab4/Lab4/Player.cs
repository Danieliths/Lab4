using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Player : GameObjekt, IinteractAble
    {
        public void CheckInteractAble(GameManager gameManager, int x, int y)
        {
            if (gameManager.Map[x,y] is IinteractAble interactable)
            {
                interactable.Interact(gameManager, (Door)interactable);
            }
            
            foreach (var objekt in gameManager.GameObjekt)
            {
                if (objekt.Location.row == x && objekt.Location.column == y && objekt is IinteractAble)
                {
                    objekt.Interact(gameManager, objekt);
                    break;
                }               
            }
        }
        public override void Interact(GameManager gameManager, GameObjekt objekt)
        {

        }
        public void Interact(GameManager gameManager, Door door)
        {

        }
        public int NumberOfMoves { get; set; }
        public List<GameObjekt> Inventory { get; set; }

        public Player()
        {
            Symbol = '@';            
            NumberOfMoves = 0;
        }        

    }
}
