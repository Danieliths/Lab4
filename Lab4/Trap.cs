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
        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.NumberOfMoves += 20;
        } // skriva ut under kartan
        public void Interact(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }
       
    }
}
