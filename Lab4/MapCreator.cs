using System.IO;

namespace Lab4
{
    class MapCreator
    {
        public MapCreator() { }        
        public void CreateMapAndObjectsFromString(string symbols, int collum, GameManager gameManager)
        {
            char[] charArray = new char[symbols.Length];
            for (int row = 0; row < symbols.Length; row++)
            {
                using (StringReader sr = new StringReader(symbols))
                {
                    sr.Read(charArray, 0, symbols.Length);
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
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), Color.Red);
                            break;
                        case 'B':
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), Color.Blue);
                            break;
                        case 'C':
                            gameManager.Map[row, collum] = new Door(new Point(row, collum), Color.Yellow);
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
                            gameManager.GameObject.Add(new Key(new Point(row, collum), Color.Red));
                            break;
                        case 'b':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Key(new Point(row, collum), Color.Blue));
                            break;
                        case 'c':
                            gameManager.Map[row, collum] = new Tile(new Point(row, collum));
                            gameManager.GameObject.Add(new Key(new Point(row, collum), Color.Yellow));
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
        public void CrateMap(GameManager gameManager)
        {           
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 0, gameManager);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 1, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 2, gameManager);
            CreateMapAndObjectsFromString("RR   T                ###                       ###                                               RR", 3, gameManager);
            CreateMapAndObjectsFromString("RR            a       ###        b               C                                     E          RR", 4, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 5, gameManager);
            CreateMapAndObjectsFromString("RR      T             ###                       ##################################################RR", 6, gameManager);
            CreateMapAndObjectsFromString("RR              T     ###           T           ##################################################RR", 7, gameManager);
            CreateMapAndObjectsFromString("RR                    ###     P                 ##################################################RR", 8, gameManager);
            CreateMapAndObjectsFromString("RR       @            ###              T        ###                                               RR", 9, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                        B            T                                   RR", 10, gameManager);
            CreateMapAndObjectsFromString("RR   T    T T         ###     T                 ###                      T      c                 RR", 11, gameManager);
            CreateMapAndObjectsFromString("RR                     A                        ###                                               RR", 12, gameManager);
            CreateMapAndObjectsFromString("RR                    ### T            T        ###           T                                   RR", 13, gameManager);
            CreateMapAndObjectsFromString("RRP         T         ###                       ###                                     T         RR", 14, gameManager);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 15, gameManager);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 16, gameManager);           
        }        
        
    }
}
