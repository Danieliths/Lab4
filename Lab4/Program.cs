using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class Program
    {
        //               TO DO Kriterier
        // 1: det ska gå att klara spelet och se sin poäng
        //   för VG
        // 1: rum kan ha fällor (synliga eller osynliga) som orsakar extra drag att ta sig över
        // ny Trap class arv av gameobject IIntreract adda mer spelar moves
        // 2: fler föremål, som kan användas på dörrar, monster eller fällor; eller som ger poäng
        // ny potion class arv av gameobject IInteract redusera spelarmoves
        // 3: rum som man inte ser vad de innehåller förrän man går in i dem ?? fog of war?

        // adda exit 
        // adda gamestate
        // adda vettig gameloop efter gamestate
        // adda winningscreen
        // adda traps
        // adda potions
        // adda player totalmoves
        static void Main(string[] args)
        {
            // sätta up en property i GameManager för gamestate? skapa gameManager innan sedan en switchcase i en whileloop?!?!? 
            //loopar det istället för att loopa vår nuvarande gameplayloop?
            
            
            Player player = new Player();           
            MapRenderer renderMap = new MapRenderer();
            Input input = new Input();
            MovementController movement = new MovementController();
            MapCreator mapCreator = new MapCreator();
            GameManager gameManager = new GameManager();
            player.Inventory = new List<GameObject>();                        
            gameManager.GameObject = new List<GameObject>();
            gameManager.Player = player;
            gameManager.Map = new Construkt[100, 17];
            mapCreator.CrateMap(gameManager);
            Console.CursorVisible = false;
            renderMap.UpdateAllPoints(gameManager);
            renderMap.PrintAroundPlayer(gameManager);
            // sätt gamestate till play

            while (true) // while gameManager.GameState == Play ?
            {
                movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
                renderMap.PrintAroundPlayer(gameManager);
            }  
            // sätta IInteractable på utgången som sätter gamestate till End?
            // kanske en Endscreen som körs och visar upp dina totala moves
            
        }
    }
}
