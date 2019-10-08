using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class Program
    {               
        static void Main(string[] args)
        {
            List<GameObjekt> gameObjekt = new List<GameObjekt>();
            Player player = new Player();
            Construkt[,] map = new Construkt[100,17];
            RenderMap renderMap = new RenderMap();
            Input input = new Input();
            Movement movement = new Movement();
            player.Inventory = new List<GameObjekt>();            
            void CreateMapAndObjectsFromString(string symbols, int collum)
            {
                char[] charArray = new char[symbols.Length];
                for (int i = 0; i < symbols.Length; i++)
                {
                    using (StringReader sr = new StringReader(symbols))
                    {
                        sr.Read(charArray, 0, symbols.Length);
                        switch (charArray[i])
                        {
                            case '#':
                                map[i, collum] = new Wall(new Point(i, collum));
                                break;
                            case ' ':
                                map[i, collum] = new Tile(new Point(i, collum));
                                break;
                            case 'R':
                                map[i, collum] = new Wall(new Point(i, collum));
                                map[i, collum].Revealed = true;
                                break;
                            case 'A':
                                map[i, collum] = new Door(new Point(i, collum), Color.Red);
                                break;
                            case 'B':
                                map[i, collum] = new Door(new Point(i, collum), Color.Blue);
                                break;
                            case 'C':
                                map[i, collum] = new Door(new Point(i, collum), Color.Yellow);
                                break;
                            default:
                                break;
                        }
                        switch (charArray[i])
                        {
                            case '@':
                                map[i, collum] = new Tile(new Point(i, collum));
                                player.Location = new Point(i, collum);
                                gameObjekt.Add(player);
                                break;
                            case 'a':
                                map[i, collum] = new Tile(new Point(i, collum));
                                gameObjekt.Add(new Key(new Point(i, collum), Color.Red));
                                break;
                            case 'b':
                                map[i, collum] = new Tile(new Point(i, collum));
                                gameObjekt.Add(new Key(new Point(i, collum), Color.Blue));
                                break;
                            case 'c':
                                map[i, collum] = new Tile(new Point(i, collum));
                                gameObjekt.Add(new Key(new Point(i, collum), Color.Yellow));
                                break;
                            default:
                                break;
                        }                       
                    }
                }
            } // Bryt ut from main så att den inte är nästlad i main
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 0);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 1);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 2);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 3);
            CreateMapAndObjectsFromString("RR            a       ###        b               C                                                RR", 4);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 5);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 6);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 7);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 8);
            CreateMapAndObjectsFromString("RR       @            ###                       ###                                               RR", 9);
            CreateMapAndObjectsFromString("RR                    ###                        B                                                RR", 10);
            CreateMapAndObjectsFromString("RR                    ###                       ###                             c                 RR", 11);
            CreateMapAndObjectsFromString("RR                     A                        ###                                               RR", 12);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 13);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 14);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 15);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 16);
            GameManager gameManager = new GameManager();
            gameManager.GameObjekt = gameObjekt;
            gameManager.Player = player;
            gameManager.Map = map;            
            renderMap.UpdateAllPoints(gameManager);
            renderMap.PrintAroundPlayer(gameManager);

            while (true)
            {
                movement.ObjektMovment(gameManager, player, input.DirectionInput(gameManager));
                renderMap.PrintAroundPlayer(gameManager);
            }                                                                    
        }
    }
}
