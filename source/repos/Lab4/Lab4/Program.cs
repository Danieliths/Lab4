using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class Program
    {               
        static void Main(string[] args)
        {
            List<GameObject> gameObjekt = new List<GameObject>();
            Player player = new Player();
            Construkt[,] map = new Construkt[100,17];
            RenderMap renderMap = new RenderMap();
            Input input = new Input();
            Movement movement = new Movement();
            MapCreator mapCreator = new MapCreator();
            GameManager gameManager = new GameManager();
            player.Inventory = new List<GameObject>();                        
            gameManager.GameObject = gameObjekt;
            gameManager.Player = player;
            gameManager.Map = map;            
            mapCreator.CrateMap(gameManager);
            renderMap.UpdateAllPoints(gameManager);
            renderMap.PrintAroundPlayer(gameManager);


            while (true)
            {
                movement.ObjectMovment(gameManager, player, input.DirectionInput(gameManager));
                renderMap.PrintAroundPlayer(gameManager);
            }                                                                    
        }
    }
}
