using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles spawning weldable objects, placing them in the world,
/// and activating weld points via raycasts while welding is active.
/// </summary>
public class WeldingManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask weldMask;
    [SerializeField] private UnityEvent onWeldStart;

    [Header("Weldable Prefabs")]
    [SerializeField] private GameObject weldObject1;
    [SerializeField] private GameObject weldObject2;
    [SerializeField] private GameObject weldObject3;

    GameObject _currentObject;
    WeldObject _currentWeldTarget;
    bool _active;
    bool _placed;

    void Update()
    {
        if (!_active || _currentWeldTarget == null)
            return;

        _HandlePlacement();
        _HandleWeldingRaycast();
    }

    void _HandlePlacement()
    {
        if (_placed) return;

        if (Input.GetMouseButtonDown(0))
        {
            _currentObject.transform.SetParent(null);
            _placed = true;
            onWeldStart?.Invoke();
        }
    }

    void _HandleWeldingRaycast()
    {
        if (!_placed)
            return;

        if (!Input.GetMouseButton(0))
            return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 500f, weldMask))
        {
            var target = hit.collider.GetComponent<WeldPoint>();
            target.Activate();
        }
    }

    void SpawnInternal(GameObject prefab)
    {
        _currentObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        _currentWeldTarget = _currentObject.GetComponent<WeldObject>();
        _active = true;
        _placed = false;
    }

    public void ReadyWeldObject1()
    {
        SpawnInternal(weldObject1);
    }

    public void ReadyWeldObject2()
    {
        SpawnInternal(weldObject2);
    }

    public void ReadyWeldObject3()
    {
        SpawnInternal(weldObject3);
    }

    public void DisableWelding()
    {
        _active = false;
    }
}