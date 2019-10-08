namespace Lab4
{
    interface IInteractAble
    {
        void Interact(GameManager gameManager, GameObject gameObject);
        void Interact(GameManager gameManager, Construkt construkt);
    }
}