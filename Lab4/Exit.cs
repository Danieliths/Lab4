using System;

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
            EntityColor = ConsoleColor.Green;
        }        
        public void Interact(GameManager gameManager, Entity entity)
        {
            gameManager.GameState = GameState.EndScreen;
        }
        public void Event(GameManager gameManager, Entity entity) { }
        
    }
}
