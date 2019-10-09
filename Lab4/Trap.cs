using System;

namespace Lab4
{
    class Trap : GameObject, IInteractAble
    {                       
        public Trap(Point location)
        {
            Symbol = 'T';            
            Location = location;
            EntityColor = ConsoleColor.Red;
        }
        public void Event(GameManager gameManager, Entity entity)
        {
            Console.Write("You got stuck in a trap for 50 moves");
        }
        public void Interact(GameManager gameManager, Entity entity)
        {
            gameManager.Player.NumberOfMoves += 50;
            gameManager.EventObject.Add(this);
            gameManager.GameObject.Remove(this);
        }                              
    }
}
