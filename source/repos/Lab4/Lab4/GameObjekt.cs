namespace Lab4
{
    abstract class GameObject : Entity, IInteractAble, IChangeColor
    {
        public virtual void Interact(GameManager gameManager, GameObject gameObject) { }
        public virtual void Interact(GameManager gameManager, Door door) { }
        public virtual void PrintColoredSymbol(GameManager game, Color color) { }
        public Color ObjectColor { get; set; }        
    }
}