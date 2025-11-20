using UnityEngine;
using UnityEngine.Events;

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