namespace Lab4
{
    interface IInteractAble
    {
        void Interact(GameManager gameManager, GameObjekt objekt);
        void Interact(GameManager gameManager, Door door);
    }
}