using System;

namespace Lab4
{
    class Trap : GameObject, IInteractAble
    {                       
        public Trap(Point location)
        {
            Symbol = 'T';            
            Location = location;
            ObjectColor = Color.Red;
        }

        public void Event(GameManager gameManager, GameObject gameObject)
        {
            Console.Write("You got stuck in a trap for 50 moves");
        }

        public void Event(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }

        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.NumberOfMoves += 50;
            gameManager.EventObject.Add(gameObject);
            gameManager.GameObject.Remove(gameObject);
        }
        public void Interact(GameManager gameManager, Construkt construkt) { }
        
          
        
       
    }
}
