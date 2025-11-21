using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles player interaction with a workbench, invoking events
/// and showing the crafting window when activated.
/// </summary>
public class Workbench : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject craftingWindow;
    [SerializeField] private UnityEvent onInteract;
    
    private bool _open;

    void Awake()
    {
        if (craftingWindow != null)
            craftingWindow.SetActive(false);
    }

    void Open()
    {
        onInteract?.Invoke();
        _open = true;
    }
    
    // Called by Interaction system
    public void Interact()
    {
        Open();
    }

    public string GetInteractName() => "Use Workbench 'E'";
}
