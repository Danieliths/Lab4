using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Player : GameObject, IInteractAble, IChangeColor
    {
        public void CheckInteractAble(GameManager gameManager, int row, int column)
        {
            if (gameManager.Map[row,column] is IInteractAble interactable)
            {
                interactable.Interact(gameManager, (Door)interactable);
            }
            
            foreach (var gameObject in gameManager.GameObject)
            {
                if (gameObject.Location.row == row && gameObject.Location.column == column && gameObject is IInteractAble)
                {
                    gameObject.Interact(gameManager, gameObject);
                    break;
                }               
            }
        }
        public override void Interact(GameManager gameManager, GameObject gameObject) { }        
        public override void Interact(GameManager gameManager, Door door) { }
        public int NumberOfMoves { get; set; }
        public List<GameObject> Inventory { get; set; }
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
        public Player()
        {
            Symbol = '@';            
            NumberOfMoves = 0;
            ObjectColor = Color.Red;
        }        
    }
}
