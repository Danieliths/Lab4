using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    // Highscore
    // Alex 207 moves
    // Emil 217 moves
    // John 221 moves
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
                        gameManager.GameObject = new List<GameObject>();
                        gameManager.Player = player;
                        gameManager.Map = new Construkt[100, 17];
                        gameManager.EventObject = new List<GameObject>();
                        Console.CursorVisible = false;
                        mapCreator.CreateMap(gameManager);
                        mapRenderer.UpdateAllPoints(gameManager);
                        mapRenderer.PrintInstructionWindow();
                        gameManager.GameState = GameState.Playing;
                        break;

                    case GameState.Playing:
                        mapRenderer.PrintInventory(gameManager);
                        mapRenderer.PrintAroundPlayer(gameManager);
                        mapRenderer.PrintEvent(gameManager);
                        mapRenderer.PrintNumberOfMoves(gameManager);
                        movement.ObjectMovement(gameManager, player, input.DirectionInput(gameManager));
                        break;

                    case GameState.EndScreen:
                        Console.Clear();
                        mapRenderer.PrintEndScreen(gameManager);
                        gameManager.GameState = GameState.ExitGame;
                        Console.ReadKey();
                        break;
                    
                    default:
                        break;
                }
            } 
        }
    }
}
