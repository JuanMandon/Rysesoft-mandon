using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
