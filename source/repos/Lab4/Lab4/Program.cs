using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{

    class Program
    {
        
        static void Main(string[] args)
        {
            // statemaskin som kollar vilken del av spelat vi är i
            // T.ex. inizilize playgame win
            // själva gameloopen skall ligga här i
            // Enum skall finnas här

            //GameState gameState = new GameState();
            //DataInInitializer init = new DataInInitializer();
            //RenderMap u = new RenderMap();            
            //init.InitializLevelOne();
            //u.UpdateAllPoints();
            //u.PrintGameBoard();
            List<GameObjekt> gameObjekt = new List<GameObjekt>();
            Player player = new Player();
            Construkt[,] map = new Construkt[100,17];
            RenderMap renderMap = new RenderMap();
            Input input = new Input();
            Movement movement = new Movement();
            player.Inventory = new List<GameObjekt>();            
            void SparaObjektPåRättPlats(string symbols, int collum)
            {
                char[] b = new char[symbols.Length];
                for (int i = 0; i < symbols.Length; i++)
                {
                    using (StringReader sr = new StringReader(symbols))
                    {
                        sr.Read(b, 0, symbols.Length);
                        if (b[i] == '#')
                        {
                            map[i, collum] = new Wall(new Point(i, collum));
                        }
                        else if (b[i] == ' ')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                        }
                        else if (b[i] == 'D')
                        {
                            map[i, collum] = new Door(new Point(i, collum));
                        }
                        else if (b[i] == 'R')
                        {
                            map[i, collum] = new Wall(new Point(i, collum));
                            map[i, collum].Revealed = true;
                        }
                        if (b[i] == '@')
                        {
                            map[i, collum] = new Tile(new Point(i, collum));
                            player.Location = new Point(i, collum);
                            gameObjekt.Add(player);
                        }
                        if (b[i] == 'K') // olika för olika färger
                        {
                            map[i, collum] = new Tile(new Point(i, collum));                           
                            gameObjekt.Add(new Key(new Point(i, collum)));
                        }
                    }
                }
            }
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 0);
            SparaObjektPåRättPlats("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 1);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 2);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 3);
            SparaObjektPåRättPlats("RR            K       ###        K               D                                                RR", 4);
            SparaObjektPåRättPlats("RR                    ###                       ###                                               RR", 5);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 6);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 7);
            SparaObjektPåRättPlats("RR                    ###                       ##################################################RR", 8);
            SparaObjektPåRättPlats("RR       @            ###                       ###                                               RR", 9);
            SparaObjektPåRättPlats("RR                    ###                        D                                                RR", 10);
            SparaObjektPåRättPlats("RR                    ###                       ###                             K                 RR", 11);
            SparaObjektPåRättPlats("RR                     D                        ###                                               RR", 12);
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

            for (int i = 0; i < 300; i++)
            {
                movement.ObjektMovment(gameManager, player, input.DirectionInput(gameManager));
                renderMap.PrintAroundPlayer(gameManager);
            }
                
            

            


        }
    }
}
