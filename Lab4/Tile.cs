namespace Lab4
{
    class Tile : Construkt
    {        
        public Tile(Point location)
        {
            Symbol = ' ';
            Revealed = false;
            CrossAble = true;
            Location = location;
            ConstruktColor = Color.Gray;
        }
    }
}