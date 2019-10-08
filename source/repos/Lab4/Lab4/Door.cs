using System;

namespace Lab4
{
    class Door : Construkt, IInteractAble
    {       
        public void Interact(GameManager gameManager, Construkt construkt)
        {
            foreach (GameObject gameObject in gameManager.Player.Inventory)
            {
                if (gameObject.ObjectColor == construkt.ConstruktColor)
                {
                    construkt.CrossAble = true;
                    construkt.Symbol = '_';
                    gameManager.Player.Inventory.Remove(gameObject);
                    break;
                }
            }           
        }
        public override void PrintColoredSymbol(GameManager gameManager, Color color)
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
        public void Interact(GameManager gameManager, GameObject gameObject) { }
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