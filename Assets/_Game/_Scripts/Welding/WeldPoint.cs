using UnityEngine;

/// <summary>
/// Handles an individual weld point: stores activation state, shows visuals,
/// plays particle effects, and notifies its parent WeldObject when activated.
/// </summary>
public class WeldPoint : MonoBehaviour
{
    [HideInInspector] public bool Activated;

    WeldObject _parent;
    SphereCollider _collider;
    Renderer _renderer;
    ParticleSystem[] _particles;

    void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _renderer = GetComponentInChildren<Renderer>(true);
        _particles = GetComponentsInChildren<ParticleSystem>(true);

        if (_renderer != null)
            _renderer.enabled = false;
    }

    public void Init(WeldObject parent)
    {
        _parent = parent;
    }

    public void Activate()
    {
        if (Activated)
            return;

        Activated = true;

        if (_renderer != null)
            _renderer.enabled = true;

        if (_particles != null)
        {
            for (int i = 0; i < _particles.Length; i++)
                _particles[i].Play();
        }

        _parent.NotifyPointActivated();
    }

    public SphereCollider GetCollider() => _collider;
}