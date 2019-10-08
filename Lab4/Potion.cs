using System;

namespace Lab4
{
    class Potion : GameObject, IInteractAble
    {
        public Potion(Point location)
        {
            Symbol = 'P';
            Location = location;
            ObjectColor = Color.Green;
        }

        public void Event(GameManager gameManager, GameObject gameObject)
        {
            Console.Write("You consume the tasty potion and it feels like you lost 30 Moves");
        }

        public void Event(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }

        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.NumberOfMoves -= 30;
            gameManager.EventObject.Add(gameObject);
            gameManager.GameObject.Remove(gameObject);
        }

        public void Interact(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }
    }
}
