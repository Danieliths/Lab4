using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{ 
    class MapRenderer
    {
        public void UodatePoint(GameManager gameManager, int row, int column)
        {
            if (gameManager.Map[row, column].Revealed == true)
            {
                Console.SetCursorPosition(row, column);
                PrintColoredSymbol(gameManager, gameManager.Map[row, column].EntityColor, gameManager.Map[row, column].Symbol);                               
                foreach (var gameObject in gameManager.GameObject)
                {
                    Console.SetCursorPosition(row, column);                    
                    if (gameObject.Location.row == row && gameObject.Location.column == column)
                    {
                        PrintColoredSymbol(gameManager, gameObject.EntityColor, gameObject.Symbol);                       
                    }
                }
            }
        }
        void PrintColoredSymbol(GameManager gameManager, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ForegroundColor = ConsoleColor.Gray;                   
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
        }       
        public void PrintInventory(GameManager gameManager)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("Keys: ");
            foreach (var gameObject in gameManager.Player.Inventory)
            {
                PrintColoredSymbol(gameManager, gameObject.EntityColor,gameObject.Symbol);
                Console.Write(" ");
            }
            Console.Write(" ");
        } 
        public void PrintNumberOfMoves(GameManager gameManager)
        {
            Console.SetCursorPosition(0, 21);
            Console.Write("Moves: {0}   ", gameManager.Player.NumberOfMoves );
            Console.SetCursorPosition(gameManager.Player.Location.row, gameManager.Player.Location.column);
        }
        public void PrintEvent(GameManager gameManager)
        {
            int eventNummer = 0;
            if (gameManager.EventObject.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.Write("                                                 ");
                }
            }
            foreach (IInteractAble interactAble in gameManager.EventObject)
            {                
                Console.SetCursorPosition(0, 22 + eventNummer);
                interactAble.Event(gameManager, (GameObject)interactAble);
                eventNummer++;
                Console.SetCursorPosition(gameManager.Player.Location.row, gameManager.Player.Location.column);
            }
            gameManager.EventObject.RemoveRange(0, gameManager.EventObject.Count);            
        }        
        public void PrintInstructionWindow()
        {
            string instructionWindow =
                $"*******************************\n" +
                $"*       The escape room       *\n" +
                $"*                             *\n" +
                $"*  Movement: w,a,s,d          *\n" +
                $"*  Key:     K                 *\n" +
                $"*  Trap:    T                 *\n" +
                $"*  Potion:  P                 *\n" +
                $"*  Door:    D                 *\n" +
                $"*  Exit:    E                 *\n" +
                $"*******************************";
            var stringRow = instructionWindow.Split("\n");
            for (int i = 0; i < stringRow.Length; i++)
            {
                Console.SetCursorPosition(50, i+ 20);
                Console.Write(stringRow[i]);
            }
        }                
        public void PrintEndScreen(GameManager gameManager)
        {
            Console.WriteLine(
                "**********************************************************************************\n" +
                "**********************************************************************************\n" +
                "**********                 Congratz, you won the game!                  **********\n" +
                "**********                                                              **********\n" +
                "**********                 You used {0} Moves                           **********\n" +
                "**********                                                              **********\n" +
                "**********************************************************************************\n" +
                "**********************************************************************************\n" +
                "**********                         Hightscore                           **********\n" +
                "**********     1: Alex: 207 Moves                                       **********\n" +
                "**********     2: Emil: 217 Moves                                       **********\n" +
                "**********     3: John: 221 Moves                                       **********\n" +
                "**********                                                              **********\n" +
                "**********************************************************************************\n" +
                "**********************************************************************************\n" +
                "**********                                                              **********\n" +
                "**********                press any key to close the game               **********\n" +
                "**********                                                              **********\n" +
                "**********************************************************************************\n" +
                "**********************************************************************************\n", gameManager.Player.NumberOfMoves);
        }
    }
}
