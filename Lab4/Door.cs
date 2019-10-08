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
                    gameManager.Player.Inventory.Remove(gameObject);
                    break;
                }
            }           
        }       
        public void Interact(GameManager gameManager, GameObject gameObject) { }
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