using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class Program
    {      
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            Player player = new Player();
            MapRenderer mapRenderer = new MapRenderer();
            InputManager input = new InputManager();
            MovementController movement = new MovementController();
            MapCreator mapCreator = new MapCreator();            
            while (gameManager.GameState != GameState.ExitGame)
            {                
                switch (gameManager.GameState)
                {
                    case GameState.SetUp:                        
                        player.Inventory = new List<GameObject>();
                        gameManager.GameObject = new List<GameObject>(); // skapa dessa i konstruktorn för gameManager?
                        gameManager.Player = player;
                        gameManager.Map = new Construkt[100, 17];
                        gameManager.EventObject = new List<GameObject>();
                        Console.CursorVisible = false;
                        mapCreator.CreateMap(gameManager);
                        mapRenderer.UpdateAllPoints(gameManager);
                        mapRenderer.PrintInstructionWindow();
                        gameManager.SetGameState(GameState.Playing);
                        break;

                    case GameState.Playing:
                        mapRenderer.PrintInventory(gameManager);
                        mapRenderer.PrintAroundPlayer(gameManager);
                        mapRenderer.PrintEvent(gameManager);
                        mapRenderer.PrintNumberOfMoves(gameManager);
                        movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
                        break;

                    case GameState.EndScreen:
                        Console.Clear();
                        mapRenderer.PrintEndScreen(gameManager);
                        gameManager.SetGameState(GameState.ExitGame);
                        Console.ReadKey();
                        break;
                    
                    default:
                        break;
                }
            } 
        }
    }
}
