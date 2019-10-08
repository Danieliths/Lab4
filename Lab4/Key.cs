using System;

namespace Lab4
{
    class Key : GameObject, IInteractAble
    {
        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.Inventory.Add(gameObject);
            gameManager.GameObject.Remove(gameObject);
        }
        public void Interact(GameManager gameManager, Construkt construkt) { }        
        public Key(Point location, Color color)
        {
            Symbol = 'K';
            Location = location;
            ObjectColor = color;
        }
    }
}