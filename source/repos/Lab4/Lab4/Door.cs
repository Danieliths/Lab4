using System;

namespace Lab4
{
    class Door : Construkt, IInteractAble
    {       
        public void Interact(GameManager gameManager, Door door)
        {
            foreach (GameObjekt objekt in gameManager.Player.Inventory)
            {
                if (objekt.ObjektColor == door.ConstruktColor)
                {
                    door.CrossAble = true;
                    door.Symbol = '_';
                    gameManager.Player.Inventory.Remove(objekt);
                    break;
                }
            }           
        }
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
        public void Interact(GameManager gameManager, GameObjekt objekt)
        {
            
        }
        public Door(Point location, Color color)
        {
            Symbol = 'D';
            Revealed = false;
            CrossAble = false;
            Location = location;
            ConstruktColor = color;            
        }
    }
}