using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{ 
    class RenderMap
    {
        public void UodatePoint(GameManager gameManager, int row, int column)
        {
            if (gameManager.Map[row, column].Revealed == false)
            {
                return;
            }
            if (gameManager.Map[row, column].Revealed == true)
            {
                Console.SetCursorPosition(row, column);
                if (gameManager.Map[row,column].ConstruktColor != Color.Gray)
                {
                    gameManager.Map[row, column].PrintColoredSymbol(gameManager, gameManager.Map[row, column].ConstruktColor);
                }
                else
                {
                    Console.Write(gameManager.Map[row,column].Symbol);
                }               
                foreach (var objekt in gameManager.GameObject)
                {
                    Console.SetCursorPosition(row, column);                    
                    if (objekt.Location.row == row && objekt.Location.column == column)
                    {
                        objekt.PrintColoredSymbol(gameManager, objekt.ObjectColor);                       
                    }
                }
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
                    UodatePoint(gameManager, row, column);
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
    }
}
