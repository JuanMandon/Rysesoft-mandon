using UnityEngine;

/// <summary>
/// Toggles between gameplay mode and UI mode by enabling/disabling
/// cursor lock and the player's look script.
/// </summary>
public class UIModeController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour playerLook;

    bool _uiMode;

    void Awake()
    {
        LockCursor();
    }
    
    void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void EnableUIMode()
    {
        if (_uiMode) return;
        _uiMode = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (playerLook != null)
            playerLook.enabled = false;
    }

    public void DisableUIMode()
    {
        if (!_uiMode) return;
        _uiMode = false;

        LockCursor();

        if (playerLook != null)
            playerLook.enabled = true;
    }
}