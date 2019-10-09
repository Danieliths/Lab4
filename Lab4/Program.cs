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
            gameManager.Gamestate = GameState.SetUp;
            Player player = new Player();
            MapRenderer mapRenderer = new MapRenderer();
            InputManager input = new InputManager();
            MovementController movement = new MovementController();
            MapCreator mapCreator = new MapCreator();
            do
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
                        mapRenderer.PrintAroundPlayer(gameManager);
                        mapRenderer.PrintEvent(gameManager);
                        mapRenderer.PrintNumberOfMoves(gameManager);
                        movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
                        break;

                    case GameState.EndScreen:
                        Console.Clear();
                        mapRenderer.PrintEndScreen(gameManager);
                        gameManager.Gamestate = GameState.ExitGame;
                        Console.ReadKey();
                        break;
                    
                    default:
                        break;
                }
            } while (gameManager.Gamestate != GameState.ExitGame);
        }
    }
}
