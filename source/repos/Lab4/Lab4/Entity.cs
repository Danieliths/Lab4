namespace Lab4
{
    abstract class Entity
    {
        public char Symbol { get; set; }                
        public Point Location { get; set; }
    }
    abstract class Construkt : Entity
    {
        public bool CrossAble { get; set; }
        public bool Revealed { get; set; }
    }
    class Tile : Construkt
    {        
        public Tile(Point location)
        {
            Symbol = ' ';
            Revealed = false;
            CrossAble = true;
            Location = location;
        }
    }
    class Wall : Construkt
    {
        public Wall(Point location)
        {
            Symbol = '#';
            Revealed = false;
            CrossAble = false;
            Location = location;
        }
    }
    class Door : Construkt
    {
        public string KeyColor { get; set; }
        public Door(Point location)
        {
            Symbol = 'D';
            Revealed = false;
            CrossAble = false;
            Location = location;
             // KeyColor skall in vid senare tillfälle
             // eller kanske Keynumber för att ha en nyckel som bara passar till en viss dörr. blir lite underligt när jag skapar gameobjektsen på det sättet jag gör
             // nytt system för skapandet av dörrar/ nycklar/monster? kanske skriva typ K1,K2,D1,D2 sedan göra nummret till nästa construkt
        }
    }
    abstract class GameObjekt : Entity
    {
        // gör inget för tillfället men tror att jag kommer ha användning av detta senare
    }
    class Key : GameObjekt
    {
        public Key(Point location)
        {
            Symbol = 'K';
            Location = location;
        }
    }

}