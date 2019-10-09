namespace Lab4
{
    class Exit : Construkt, IInteractAble
    {
        public Exit(Point location)
        {
            Symbol = 'E';
            Revealed = false;
            CrossAble = true;
            Location = location;
            ConstruktColor = Color.Green;
        }

        public void Interact(GameManager gameManager, GameObject gameObject) { }
        public void Interact(GameManager gameManager, Construkt construkt)
        {
            gameManager.Gamestate = GameState.EndScreen;
        }
        public void Event(GameManager gameManager, GameObject gameObject) { }
        public void Event(GameManager gameManager, Construkt construkt) { }
    }
}
