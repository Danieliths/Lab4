using System;

namespace Lab4
{
    class Key : GameObject, IInteractAble
    {
        public void Interact(GameManager gameManager, GameObject gameObject)
        {
            gameManager.Player.Inventory.Add(gameObject);            
            gameManager.EventObject.Add(new Key(new Point(0, 0), gameObject.ObjectColor));
            gameManager.GameObject.Remove(gameObject);
        }
        public void Interact(GameManager gameManager, Construkt construkt) { }

        public void Event(GameManager gameManager, GameObject gameObject)
        {
            if (gameManager.Map[gameManager.Player.Location.row, gameManager.Player.Location.column].Symbol == '_')
            {
                Console.Write($"You used your {gameObject.ObjectColor} key");
            }
            else
            {
                Console.Write($"You pick up a {gameObject.ObjectColor} key");
            }
        }
        public void Event(GameManager gameManager, Construkt construkt) { }

        public Key(Point location, Color color)
        {
            Symbol = 'K';
            Location = location;
            ObjectColor = color;
        }
    }
}