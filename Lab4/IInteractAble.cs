namespace Lab4
{
    interface IInteractAble
    {
        void Interact(GameManager gameManager, Entity entity);    
        void Event(GameManager gameManager, Entity entity);       
    }
}