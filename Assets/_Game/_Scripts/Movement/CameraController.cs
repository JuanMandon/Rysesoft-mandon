using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First-person look controller using the old Input System for rapid prototyping.
/// Intended for quick iteration; a production system would use an event-driven input layer.
/// Handles vertical pitch rotation on the camera and yaw rotation on the player body.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 120f;
    [SerializeField] Transform playerBody;

    // Tracks accumulated vertical rotation so we can clamp camera pitch.
    float _cameraPitch;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleLook();
    }

    void HandleLook()
    {
        float mouseDeltaX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseDeltaY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        ApplyVerticalLook(mouseDeltaY);
        ApplyHorizontalLook(mouseDeltaX);
    }

    void ApplyVerticalLook(float mouseDeltaY)
    {
        _cameraPitch -= mouseDeltaY;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -85f, 85f);

        transform.localRotation = Quaternion.Euler(_cameraPitch, 0f, 0f);
    }

    void ApplyHorizontalLook(float mouseDeltaX)
    {
        playerBody.Rotate(Vector3.up * mouseDeltaX);
    }
}
