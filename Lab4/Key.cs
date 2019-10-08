using System;

namespace Lab4
{
    class Key : GameObject, IInteractAble
    {
        public void Interact(GameManager gameManager, GameObject objekt)
        {
            gameManager.Player.Inventory.Add(objekt);
            gameManager.GameObject.Remove(objekt);
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