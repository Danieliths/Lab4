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