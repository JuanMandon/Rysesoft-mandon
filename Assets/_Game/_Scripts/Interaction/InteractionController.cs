using UnityEngine;
using TMPro;

public class InteractionController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask interactMask;

    [Header("UI")]
    [SerializeField] private GameObject interactIndicator;
    [SerializeField] private TMP_Text interactLabel;

    Camera _cam;
    IInteractable _currentInteractable;

    void Awake()
    {
        _cam = Camera.main;
        interactIndicator.SetActive(false);
    }

    void Update()
    {
        CheckIfInteractable();
        HandleInteractionInput();
    }

    void CheckIfInteractable()
    {
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (_currentInteractable != interactable)
                {
                    _currentInteractable = interactable;
                    interactIndicator.SetActive(true);

                    if (interactLabel != null)
                        interactLabel.text = _currentInteractable.GetInteractName();
                }
                return;
            }
        }

        if (_currentInteractable != null)
        {
            _currentInteractable = null;
            interactIndicator.SetActive(false);
        }
    }

    void HandleInteractionInput()
    {
        if (_currentInteractable == null) return;

        if (Input.GetKeyDown(interactKey))
            _currentInteractable.Interact();
    }
}