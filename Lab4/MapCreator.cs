using System.IO;

namespace Lab4
{
    class MapCreator
    {
        

        public MapCreator() { }        
        public void CreateMapAndObjectsFromString(string symbols, int collum, GameManager gameManager)
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
                            gameManager.Map[i, collum] = new Wall(new Point(i, collum));
                            break;
                        case ' ':
                            gameManager.Map[i, collum] = new Tile(new Point(i, collum));
                            break;
                        case 'R':
                            gameManager.Map[i, collum] = new Wall(new Point(i, collum));
                            gameManager.Map[i, collum].Revealed = true;
                            break;
                        case 'A':
                            gameManager.Map[i, collum] = new Door(new Point(i, collum), Color.Red);
                            break;
                        case 'B':
                            gameManager.Map[i, collum] = new Door(new Point(i, collum), Color.Blue);
                            break;
                        case 'C':
                            gameManager.Map[i, collum] = new Door(new Point(i, collum), Color.Yellow);
                            break;
                        default:
                            break;
                    }
                    switch (charArray[i])
                    {
                        case '@':
                            gameManager.Map[i, collum] = new Tile(new Point(i, collum));
                            gameManager.Player.Location = new Point(i, collum);
                            gameManager.GameObject.Add(gameManager.Player);
                            break;
                        case 'a':
                            gameManager.Map[i, collum] = new Tile(new Point(i, collum));
                            gameManager.GameObject.Add(new Key(new Point(i, collum), Color.Red));
                            break;
                        case 'b':
                            gameManager.Map[i, collum] = new Tile(new Point(i, collum));
                            gameManager.GameObject.Add(new Key(new Point(i, collum), Color.Blue));
                            break;
                        case 'c':
                            gameManager.Map[i, collum] = new Tile(new Point(i, collum));
                            gameManager.GameObject.Add(new Key(new Point(i, collum), Color.Yellow));
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
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 3, gameManager);
            CreateMapAndObjectsFromString("RR            a       ###        b               C                                                RR", 4, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 5, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 6, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 7, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ##################################################RR", 8, gameManager);
            CreateMapAndObjectsFromString("RR       @            ###                       ###                                               RR", 9, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                        B                                                RR", 10, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                             c                 RR", 11, gameManager);
            CreateMapAndObjectsFromString("RR                     A                        ###                                               RR", 12, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 13, gameManager);
            CreateMapAndObjectsFromString("RR                    ###                       ###                                               RR", 14, gameManager);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 15, gameManager);
            CreateMapAndObjectsFromString("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", 16, gameManager);           
        }        
        
    }
}
