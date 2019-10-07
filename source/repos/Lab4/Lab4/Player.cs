using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Player : GameObjekt, IinteractAble, IchangeColor
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
        public override void Interact(GameManager gameManager, Door door)
        {

        }
        public int NumberOfMoves { get; set; }
        public List<GameObjekt> Inventory { get; set; }
        public override void ChangeColor(GameManager gameManager, Color color)
        {
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }

        }

        public Player()
        {
            Symbol = '@';            
            NumberOfMoves = 0;
            ObjektColor = Color.Red;
        }        

    }
}
