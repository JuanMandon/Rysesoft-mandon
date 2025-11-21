using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Simple interactable item-pile container that opens a UI window
/// and fires an event when the player interacts with it.
/// </summary>
public class ItemPile : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject pileWindow;
    [SerializeField] UnityEvent onInteract;

    bool _open;
    void Awake()
    {
        if (pileWindow != null)
            pileWindow.SetActive(false);
    }

    void Open()
    {
        onInteract?.Invoke();
        _open = true;

        if (pileWindow != null)
            pileWindow.SetActive(true);
    }
    
    public void Interact()
    {
        Open();
    }

    public string GetInteractName() => "Open Pile 'E'";
}