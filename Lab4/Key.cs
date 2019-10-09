using System;

namespace Lab4
{
    class Key : GameObject, IInteractAble
    {
        public void Interact(GameManager gameManager, Entity entity)
        {
            gameManager.Player.Inventory.Add(this);            
            gameManager.EventObject.Add(new Key(new Point(0, 0), EntityColor));
            gameManager.GameObject.Remove(this);
        }       
        public void Event(GameManager gameManager, Entity entity)
        {
            if (gameManager.Map[gameManager.Player.Location.row, gameManager.Player.Location.column].Symbol == '_')
            {
                Console.Write($"You used your {EntityColor} key");
            }
            else
            {
                Console.Write($"You pick up a {EntityColor} key");
            }
        }        
        public Key(Point location, ConsoleColor color)
        {
            Symbol = 'K';
            Location = location;
            EntityColor = color;
        }
    }
}