using System;

namespace Lab4
{
    class Trap : GameObject, IInteractAble
    {                       
        Trap(Point location)
        {
            Symbol = 'T';            
            Location = location;
            ObjectColor = Color.Red;
        }

        public void Event(GameManager gameManager, GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public void Event(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }

        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.NumberOfMoves += 50;
            gameManager.EventObject.Add(gameObject);
        }
        public void Interact(GameManager gameManager, Construkt construkt) { }
        
          
        
       
    }
}
