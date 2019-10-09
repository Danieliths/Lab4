using System;

namespace Lab4
{
    class Door : Construkt, IInteractAble
    {       
        public void Interact(GameManager gameManager, Entity entity)
        {
            foreach (GameObject gameObject in gameManager.Player.Inventory)
            {
                if (gameObject.EntityColor == entity.EntityColor)
                {
                    CrossAble = true;
                    Symbol = '_';
                    gameManager.EventObject.Add(gameObject);
                    gameManager.Player.Inventory.Remove(gameObject);
                    break;
                }
            }           
        }               
        public void Event(GameManager gameManager, Entity entity)
        {
            throw new NotImplementedException();
        }
        public Door(Point location, ConsoleColor color)
        {
            Symbol = 'D';
            Revealed = false;
            CrossAble = false;
            Location = location;
            EntityColor = color;            
        }
    }
}