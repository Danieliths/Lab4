using System;

namespace Lab4
{
    class Potion : GameObject, IInteractAble
    {
        public Potion(Point location)
        {
            Symbol = 'P';
            Location = location;
            EntityColor = ConsoleColor.Green;
        }
        public void Event(GameManager gameManager, Entity entity)
        {
            Console.Write("You consume a tasty potion and it feel great!\n" +
                "You lost 30 Moves");
        }
        public void Interact(GameManager gameManager, Entity entity)
        {
            gameManager.Player.NumberOfMoves -= 30;
            gameManager.EventObject.Add(this);
            gameManager.GameObject.Remove(this);
        }
    }
}
