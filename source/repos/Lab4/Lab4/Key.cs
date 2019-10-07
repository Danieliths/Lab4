﻿using System;

namespace Lab4
{
    class Key : GameObjekt
    {
        public override void Interact(GameManager gameManager, GameObjekt objekt)
        {
            gameManager.Player.Inventory.Add(objekt);
            gameManager.GameObjekt.Remove(objekt);
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
        public Key(Point location, Color color)
        {
            Symbol = 'K';
            Location = location;
            ObjektColor = color;
        }
    }
}