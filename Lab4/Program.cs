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
        // kolla på hur potionen skriver ut movementtalet. 
        
        
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Gamestate = GameState.SetUp;
            Player player = new Player();
            MapRenderer mapRenderer = new MapRenderer();
            InputManager input = new InputManager();
            MovementController movement = new MovementController();
            MapCreator mapCreator = new MapCreator();
            while (gameManager.Gamestate != GameState.ExitGame)
            {
                switch (gameManager.Gamestate)
                {
                    case GameState.SetUp:
                        player.Inventory = new List<GameObject>();
                        gameManager.GameObject = new List<GameObject>();
                        gameManager.Player = player;
                        gameManager.Map = new Construkt[100, 17];
                        gameManager.EventObject = new List<GameObject>();
                        mapCreator.CreateMap(gameManager);
                        Console.CursorVisible = false;
                        mapRenderer.UpdateAllPoints(gameManager);
                        mapRenderer.PrintInstructionWindow();
                        gameManager.Gamestate = GameState.Playing;
                        break;

                    case GameState.Playing:
                        mapRenderer.PrintInventory(gameManager);
                        mapRenderer.PrintNumberOfMoves(gameManager);
                        mapRenderer.PrintAroundPlayer(gameManager);
                        mapRenderer.PrintEvent(gameManager);
                        movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
                        break;

                    case GameState.EndScreen:

                        gameManager.Gamestate = GameState.ExitGame;
                        break;
                    case GameState.ExitGame:
                        break;
                    default:
                        break;
                }
            }


            // sätt gamestate till play

            // sätta IInteractable på utgången som sätter gamestate till End?
            // kanske en Endscreen som körs och visar upp dina totala moves

        }
    }
}
