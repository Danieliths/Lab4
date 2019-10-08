namespace Lab4
{
    abstract class GameObject : Entity, IChangeColor
    {
        public virtual void PrintColoredSymbol(GameManager game, Color color) { }
        public Color ObjectColor { get; set; }        
    }
}