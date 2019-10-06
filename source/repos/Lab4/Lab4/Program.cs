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

            void PrintGameObjekt()
            {
                foreach (var item in gameObjekt)
                {
                    Console.WriteLine(item.Symbol);
                }
            } // TA BORT SEDAN
            void PrintMap()
            {
                for (int y = 0; y < 17; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {                      
                        Console.Write(map[x, y].Symbol);
                    }
                    Console.WriteLine();
                }
            } // TA BORT SEDAN
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
            SparaObjektPåRättPlats("####################################################################################################", 0);
            SparaObjektPåRättPlats("####################################################################################################", 1);
            SparaObjektPåRättPlats("##                    ###                       ###                                               ##", 2);
            SparaObjektPåRättPlats("##            @       ###                       ###                                               ##", 3);
            SparaObjektPåRättPlats("##                    ###        K               D                                                ##", 4);
            SparaObjektPåRättPlats("##                    ###                       ###                                               ##", 5);
            SparaObjektPåRättPlats("##                    ###                       ####################################################", 6);
            SparaObjektPåRättPlats("##                    ###                       ####################################################", 7);
            SparaObjektPåRättPlats("##                    ###                       ####################################################", 8);
            SparaObjektPåRättPlats("##     K              ###                       ###                                               ##", 9);
            SparaObjektPåRättPlats("##                    ###                        D                                                ##", 10);
            SparaObjektPåRättPlats("##                    ###                       ###                             K                 ##", 11);
            SparaObjektPåRättPlats("##                     D                        ###                                               ##", 12);
            SparaObjektPåRättPlats("##                    ###                       ###                                               ##", 13);
            SparaObjektPåRättPlats("##                    ###                       ###                                               ##", 14);
            SparaObjektPåRättPlats("####################################################################################################", 15);
            SparaObjektPåRättPlats("####################################################################################################", 16);
            GameManager gameManager = new GameManager();
            gameManager.GameObjekt = gameObjekt;
            gameManager.Player = player;
            gameManager.Map = map;
            PrintMap();
            renderMap.UpdateAllPoints(gameManager);
            renderMap.PrintAroundPlayer(gameManager);
            Console.ReadKey();
            movement.ObjektMovment(gameManager, player, input.DirectionInput(gameManager));
            
            renderMap.PrintAroundPlayer(gameManager);
            Console.ReadKey();
            movement.ObjektMovment(gameManager, player, input.DirectionInput(gameManager));
            renderMap.PrintAroundPlayer(gameManager);
            Console.ReadKey();
            movement.ObjektMovment(gameManager, player, input.DirectionInput(gameManager));
            Console.ReadKey();

            


        }
    }
}
