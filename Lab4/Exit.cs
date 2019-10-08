namespace Lab4
{
    class Exit : Construkt
    {
        public Exit(Point location)
        {
            Symbol = 'E';
            Revealed = false;
            CrossAble = true;
            Location = location;
            ConstruktColor = Color.Green;
        }        
    }
}
