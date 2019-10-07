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
            void SparaObjektPåRättPlats(string symbols, int collum) // Bryt ut from main så att den inte är nästlad i main
            {
                char[] b = new char[symbols.Length];
                for (int i = 0; i < symbols.Length; i++)
                {
                    using (StringReader sr = new StringReader(symbols))
                    {
                        sr.Read(b, 0, symbols.Length); // bättre med switchsats
                        if (b[i] == '#')
                        {
                            map[i, collum] = new Wall(new Point(i, collum));
                        }
                        else if (b[i] == ' ')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                        }                        
                        else if (b[i] == 'R')
                        {
                            map[i, collum] = new Wall(new Point(i, collum));
                            map[i, collum].Revealed = true;
                        }
                        else if (b[i] == 'A')
                        {
                            map[i, collum] = new Door(new Point(i, collum), Color.Red);
                        }
                        else if (b[i] == 'B')
                        {
                            map[i, collum] = new Door(new Point(i, collum), Color.Blue);
                        }
                        else if (b[i] == 'C')
                        {
                            map[i, collum] = new Door(new Point(i, collum), Color.Yellow);
                        }

                        if (b[i] == '@')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                            player.Location = new Point(i, collum);
                            gameObjekt.Add(player);
                        }
                        if (b[i] == 'a') 
                        {
                            map[i, collum] = new Tile(new Point(i, collum));                           
                            gameObjekt.Add(new Key(new Point(i, collum), Color.Red));
                        }
                        if (b[i] == 'b')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                            gameObjekt.Add(new Key(new Point(i, collum), Color.Blue));
                        }
                        if (b[i] == 'c')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                            gameObjekt.Add(new Key(new Point(i, collum), Color.Yellow));
                        }
                    }
                }
            }
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 0);
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 1);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 2);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 3);
            SparaObjektPåRättPlats("RR            a       ###        b               C                                                RR", 4);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 5);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 6);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 7);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 8);
            SparaObjektPåRättPlats("RR       @            ###                       ###                                               RR", 9);
            SparaObjektPåRättPlats("RR                    ###                        B                                                RR", 10);
            SparaObjektPåRättPlats("RR                    ###                       ###                             c                 RR", 11);
            SparaObjektPåRättPlats("RR                     A                        ###                                               RR", 12);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 13);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 14);
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 15);
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 16);
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
