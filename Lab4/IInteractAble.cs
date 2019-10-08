namespace Lab4
{
    interface IInteractAble
    {
        void Interact(GameManager gameManager, GameObject gameObject);
        void Interact(GameManager gameManager, Construkt construkt);
        void Event(GameManager gameManager, GameObject gameObject);
        void Event(GameManager gameManager, Construkt construkt);
    }
}