using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject craftingWindow;

    private bool _open;

    // Called by Interaction system
    public void Interact()
    {
        if (_open) Close();
        else Open();
    }

    public string GetInteractName() => "Use Workbench";

    void Awake()
    {
        if (craftingWindow != null)
            craftingWindow.SetActive(false);
    }

    void Open()
    {
        _open = true;
        if (craftingWindow != null)
            craftingWindow.SetActive(true);
    }

    void Close()
    {
        _open = false;
        if (craftingWindow != null)
            craftingWindow.SetActive(false);
    }
}
