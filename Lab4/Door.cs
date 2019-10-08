using System;

namespace Lab4
{
    class Door : Construkt, IInteractAble
    {       
        public void Interact(GameManager gameManager, Construkt construkt)
        {
            foreach (GameObject gameObject in gameManager.Player.Inventory)
            {
                if (gameObject.ObjectColor == construkt.ConstruktColor)
                {
                    construkt.CrossAble = true;
                    construkt.Symbol = '_';
                    gameManager.EventObject.Add(gameObject);
                    gameManager.Player.Inventory.Remove(gameObject);
                    break;
                }
            }           
        }       
        public void Interact(GameManager gameManager, GameObject gameObject) { }

        public void Event(GameManager gameManager, GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public void Event(GameManager gameManager, Construkt construkt)
        {
            throw new NotImplementedException();
        }

        public Door(Point location, Color color)
        {
            Symbol = 'D';
            Revealed = false;
            CrossAble = false;
            Location = location;
            ConstruktColor = color;            
        }
    }
}