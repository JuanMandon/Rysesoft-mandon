/// <summary>
/// Contract for any object that can be interacted with via the interaction system.
/// </summary>
public interface IInteractable
{
    void Interact();
    string GetInteractName();
}