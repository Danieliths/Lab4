namespace Lab4
{
    abstract class GameObjekt : Entity, IInteractAble, IChangeColor
    {
        public virtual void Interact(GameManager gameManager, GameObjekt objekt) { }
        public virtual void Interact(GameManager gameManager, Door door) { }
        public virtual void ChangeColor(GameManager game, Color color) { }
        public Color ObjektColor { get; set; }        
    }
}