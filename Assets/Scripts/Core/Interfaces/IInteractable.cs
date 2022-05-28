namespace Core.Interfaces
{
    public interface IInteractable
    {
        bool CanInteract { get; }
        void Interact();
    }
}