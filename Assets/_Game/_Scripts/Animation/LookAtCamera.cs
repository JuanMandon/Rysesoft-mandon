using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
    }

    void LateUpdate()
    {
        if (_cam == null)
            return;

        var dir = transform.position - _cam.transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}