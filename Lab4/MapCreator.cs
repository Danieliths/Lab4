using System;
using System.IO;

namespace Lab4
{
    class MapCreator
    {
        public MapCreator() { }        
        public void CreateMapAndObjectsFromString(string mapLayoutRow, int collum, GameManager gameManager)
        {
            char[] charArray = new char[mapLayoutRow.Length];
            for (int row = 0; row < mapLayoutRow.Length; row++)
            {
                using (StringReader sr = new StringReader(mapLayoutRow))
                {
                    sr.Read(charArray, 0, mapLayoutRow.Length);
                    switch (charArray[row])
                    {
                        case '#':
                            gameManager.Map[row, collum] = new Wall(new Point(row, collum));
                            break;
                        case ' ':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            break;
                        case 'R':
                            gameManager.Map[row, collum] = new Wall(new Point(row, collum));
                            gameManager.Map[row, collum].Revealed = true;
                            break;
                        case 'A':
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), ConsoleColor.Red);
                            break;
                        case 'B':
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), ConsoleColor.Blue);
                            break;
                        case 'C':
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), ConsoleColor.Yellow);
                            break;
                        case 'E':
                            gameManager.Map[row, collum] = new Exit(new Point(row, collum));
                            break;
                        default:
                            break;
                    }
                    switch (charArray[row])
                    {
                        case '@':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.Player.Location = new Point(row, collum);
                            gameManager.GameObject.Add(gameManager.Player);
                            break;
                        case 'a':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Key(new Point(row, collum), ConsoleColor.Red));
                            break;
                        case 'b':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Key(new Point(row, collum), ConsoleColor.Blue));
                            break;
                        case 'c':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Key(new Point(row, collum), ConsoleColor.Yellow));
                            break;
                        case 'T':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Trap(new Point(row, collum)));
                            break;
                        case 'P':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Potion(new Point(row, collum)));
                            break;
                        default:
                            break;
                    }
                }
            }           
        }         
        public void CreateMap(GameManager gameManager)
        {
        string mapLayout =
            "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR\n" +
            "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR\n" +
            "RR                    ###                       ###                                               RR\n" +
            "RR   T                ###                       ###                                               RR\n" +
            "RR            a       ###        b               C                                     E        P RR\n" +
            "RR                    ###                       ###                                               RR\n" +
            "RR      T             ###                       ##################################################RR\n" +
            "RR              T     ###           T           ##################################################RR\n" +
            "RR                    ###                       ##################################################RR\n" +
            "RR       @            ###              T        ###                                               RR\n" +
            "RR                    ###                        B            T                                   RR\n" +
            "RR   T    T T         ###     T                 ###                      T      c                 RR\n" +
            "RR                     A                        ###                                               RR\n" +
            "RR                    ### T            T        ###           T                                   RR\n" +
            "RR  P       T         ###        P              ###                                     T         RR\n" +
            "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR\n" +
            "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
            var stringRow = mapLayout.Split("\n");
            for (int i = 0; i < stringRow.Length; i++)
            {
                Console.SetCursorPosition(50, i + 20); //namnge magiska siffror
                CreateMapAndObjectsFromString(stringRow[i], i, gameManager);
            };
        }       
    }
}
