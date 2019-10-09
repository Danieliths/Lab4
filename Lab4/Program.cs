using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class Program
    {
        //               TO DO Kriterier        
        // adda gamestate
        // adda vettig gameloop efter gamestate       
        // ändra hur events visas
        
        static void Main(string[] args)
        {
            // sätta up en property i GameManager för gamestate? skapa gameManager innan sedan en switchcase i en whileloop?!?!? 
            //loopar det istället för att loopa vår nuvarande gameplayloop?
            
            
            Player player = new Player();           
            MapRenderer mapRenderer = new MapRenderer();
            InputManager input = new InputManager();
            MovementController movement = new MovementController();
            MapCreator mapCreator = new MapCreator();
            GameManager gameManager = new GameManager();
            player.Inventory = new List<GameObject>();                        
            gameManager.GameObject = new List<GameObject>();
            gameManager.Player = player;
            gameManager.Map = new Construkt[100, 17];
            gameManager.EventObject = new List<GameObject>();
            mapCreator.CreateMap(gameManager);
            Console.CursorVisible = false;
            mapRenderer.UpdateAllPoints(gameManager);
            mapRenderer.PrintInstructionWindow();

            // sätt gamestate till play

            while (gameManager.Map[gameManager.Player.Location.row, gameManager.Player.Location.column].Symbol != 'E')
            {
                mapRenderer.PrintInventory(gameManager);
                mapRenderer.PrintNumberOfMoves(gameManager);
                mapRenderer.PrintAroundPlayer(gameManager);
                mapRenderer.PrintEvent(gameManager);
                movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
            }  
            // sätta IInteractable på utgången som sätter gamestate till End?
            // kanske en Endscreen som körs och visar upp dina totala moves
            
        }
    }
}
