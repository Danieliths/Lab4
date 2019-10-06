using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{ // kanske ska innehålla printkartan chararray för att kartan inte string
    // inte här, all rendering bör vara på samma ställe
    // gamemanger bra namn för att samla all data, det som jag för nuvarande kallar GameState
    // Enum för att hålla koll på vilket state spelet är i, typ start, playu,  t.ex.
    // statemaskinen ska bara ha en state och köra den staten och sedan byta när det är dax. det är allt som skall vara i den.
    // kommer statemaskinen fungera som en gameloop? ja
    // spelarposition mm skall vara sparad på spelarobjektet och sedan tas in i gamemaneger
    // delta är ändringen mella två saker
    // i gamemaangeren ska bara ha massa getset så man kan ta ut den datan man man vill ha
    class RenderMap
    {
        public void UodatePoint(GameManager gameManager, int x, int y)
        {
            if (gameManager.Map[x, y].Revealed == false)
            {
                return;
            }
            else if (gameManager.Map[x, y].Revealed == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(gameManager.Map[x,y].Symbol);
                
                foreach (var objekt in gameManager.GameObjekt)
                {
                    Console.SetCursorPosition(x, y);
                    
                    if (objekt.Location.row == x && objekt.Location.column == y)
                    {
                        Console.Write(objekt.Symbol);
                    }
                }
            }
        }
        public void UpdateAllPoints(GameManager gameManager)
        {
            for (int y = 0; y < 17; y++)
            {
                for (int x = 0; x < 100; x++)
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
        //test för commit

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
