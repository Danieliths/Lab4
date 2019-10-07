using System;

namespace Lab4
{
    
    abstract class Entity
    {
        public char Symbol { get; set; }                
        public Point Location { get; set; }
    }
    abstract class Construkt : Entity, IchangeColor
    {
        public bool CrossAble { get; set; }
        public bool Revealed { get; set; }
        public Color ConstruktColor { get; set; }
        public virtual void ChangeColor(GameManager game, Color color) { }

    }
    class Tile : Construkt
    {        
        public Tile(Point location)
        {
            Symbol = ' ';
            Revealed = false;
            CrossAble = true;
            Location = location;
            ConstruktColor = Color.Gray;
        }
    }
    class Wall : Construkt
    {
        public Wall(Point location)
        {
            Symbol = '#';
            Revealed = false;
            CrossAble = false;
            Location = location;
            ConstruktColor = Color.Gray;
        }
    }
    class Door : Construkt, IinteractAble
    {
        
        public void Interact(GameManager gameManager, Door door)
        {
            foreach (GameObjekt objekt in gameManager.Player.Inventory)
            {
                if (objekt.ObjektColor == door.ConstruktColor)
                {
                    door.CrossAble = true;
                    door.Symbol = '_';
                    gameManager.Player.Inventory.Remove(objekt);
                    break;
                }
            }           
        }
        public override void ChangeColor(GameManager gameManager, Color color)
        {
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }

        }
        public void Interact(GameManager gameManager, GameObjekt objekt)
        {
            
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
    abstract class GameObjekt : Entity, IinteractAble, IchangeColor
    {
        public virtual void Interact(GameManager gameManager, GameObjekt objekt) { }
        public virtual void Interact(GameManager gameManager, Door door) { }
        public virtual void ChangeColor(GameManager game, Color color) { }
        public Color ObjektColor { get; set; }
        
    }
    class Key : GameObjekt
    {
        public override void Interact(GameManager gameManager, GameObjekt objekt)
        {
            gameManager.Player.Inventory.Add(objekt);
            gameManager.GameObjekt.Remove(objekt);
        }
        public override void ChangeColor(GameManager gameManager, Color color)
        {
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }
            
        }
        public Key(Point location, Color color)
        {
            Symbol = 'K';
            Location = location;
            ObjektColor = color;
        }
    }
    interface IinteractAble
    {
        void Interact(GameManager gameManager, GameObjekt objekt);
        void Interact(GameManager gameManager, Door door);

    }
    interface IchangeColor
    {
        void ChangeColor(GameManager game, Color color);
        
    }
}