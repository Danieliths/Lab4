namespace Lab4
{
    abstract class Construkt : Entity, IChangeColor
    {
        public bool CrossAble { get; set; }
        public bool Revealed { get; set; }
        public Color ConstruktColor { get; set; }
        public virtual void PrintColoredSymbol(GameManager gameManager, Color color) { }
    }
}