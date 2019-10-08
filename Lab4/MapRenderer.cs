﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{ 
    class MapRenderer
    {
        private int eventNumber = 1;
        public void UodatePoint(GameManager gameManager, int row, int column)
        {
            if (gameManager.Map[row, column].Revealed == false)
            {
                return;
            }
            if (gameManager.Map[row, column].Revealed == true)
            {
                Console.SetCursorPosition(row, column);
                PrintColoredSymbol(gameManager, gameManager.Map[row, column].ConstruktColor, gameManager.Map[row, column].Symbol);                               
                foreach (var gameObject in gameManager.GameObject)
                {
                    Console.SetCursorPosition(row, column);                    
                    if (gameObject.Location.row == row && gameObject.Location.column == column)
                    {
                        PrintColoredSymbol(gameManager, gameObject.ObjectColor, gameObject.Symbol);                       
                    }
                }
            }
        }
        void PrintColoredSymbol(GameManager gameManager, Color color, char symbol)
        {
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }
        }
        public void UpdateAllPoints(GameManager gameManager)
        {
            
            for (int column = 0; column < gameManager.Map.GetLength(1); column++)
            {
                for (int row = 0; row < gameManager.Map.GetLength(0); row++)
                {
                    Console.SetCursorPosition(row, column);
                    if (gameManager.Map[row, column].Revealed == false)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        UodatePoint(gameManager, row, column);
                    }
                }
            }
        }
        public void PrintAroundPlayer(GameManager gameManager)
        {
            for (int x = gameManager.Player.Location.row - 2; x < gameManager.Player.Location.row + 3; x++)
            {
                for (int y = gameManager.Player.Location.column -2; y < gameManager.Player.Location.column + 3; y++)
                {
                    gameManager.Map[x, y].Revealed = true;
                    UodatePoint(gameManager, x, y);
                }
            }
            Console.SetCursorPosition(gameManager.Player.Location.row, gameManager.Player.Location.column);
        }       
        public void PrintInventory(GameManager gameManager)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("Keys: ");
            foreach (var gameObject in gameManager.Player.Inventory)
            {
                PrintColoredSymbol(gameManager, gameObject.ObjectColor,gameObject.Symbol);
                Console.Write(" ");
            }
            Console.Write(" ");
        }
        public void PrintNumberOfMoves(GameManager gameManager)
        {
            Console.SetCursorPosition(0, 21);
            Console.Write("Moves: " + gameManager.Player.NumberOfMoves);
        }
        public void PrintEvents(GameManager gameManager)
        {
            foreach (IInteractAble interactAble in gameManager.EventObject)
            {
                Console.SetCursorPosition(0, 21 + eventNumber);
                eventNumber++;
                interactAble.Event(gameManager, (GameObject)interactAble);
                Console.SetCursorPosition(gameManager.Player.Location.row, gameManager.Player.Location.column);

            }
            gameManager.EventObject.RemoveRange(0, gameManager.EventObject.Count);
            
        }
    }
}
