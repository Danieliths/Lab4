using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{ 
    class RenderMap
    {
        public void UodatePoint(GameManager gameManager, int x, int y)
        {
            if (gameManager.Map[x, y].Revealed == false)
            {
                return;
            }
            if (gameManager.Map[x, y].Revealed == true)
            {
                Console.SetCursorPosition(x, y);
                if (gameManager.Map[x,y].ConstruktColor != Color.Gray)
                {
                    gameManager.Map[x, y].PrintColoredSymbol(gameManager, gameManager.Map[x, y].ConstruktColor);
                }
                else
                {
                    Console.Write(gameManager.Map[x,y].Symbol);
                }               
                foreach (var objekt in gameManager.GameObject)
                {
                    Console.SetCursorPosition(x, y);                    
                    if (objekt.Location.row == x && objekt.Location.column == y)
                    {
                        objekt.PrintColoredSymbol(gameManager, objekt.ObjectColor);                       
                    }
                }
            }
        }
        public void UpdateAllPoints(GameManager gameManager)
        {
            for (int y = 0; y < 17; y++) // byta ut 17 mot tex mapHight
            {
                for (int x = 0; x < 100; x++) // byta ut 100 mot tex mapBredd eller Map.Leanth eller liknande
                {
                    Console.SetCursorPosition(x, y);
                    if (gameManager.Map[x, y].Revealed == false)
                    {
                        Console.Write("X");
                    }
                    UodatePoint(gameManager, x, y);
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
