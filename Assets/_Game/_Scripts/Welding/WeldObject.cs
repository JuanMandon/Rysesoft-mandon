using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class WeldObject : MonoBehaviour
{
    [SerializeField] private TMP_Text weldText;
    [SerializeField] private ParticleSystem[] particles;
    [SerializeField] private UnityEvent onCompletedWeld;

    WeldPoint[] _points;
    int _activated;

    Vector3 _initialScale;

    void Awake()
    {
        _points = GetComponentsInChildren<WeldPoint>(true);

        for (int i = 0; i < _points.Length; i++)
            _points[i].Init(this);

        _initialScale = transform.localScale;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (weldText == null)
            return;

        float p = (float)_activated / _points.Length;
        weldText.text = Mathf.RoundToInt(p * 100f) + "%";
    }

    void FullyWeldedEffect()
    {
        if (particles != null)
        {
            for (int i = 0; i < particles.Length; i++)
                if (particles[i] != null)
                    particles[i].Play();
        }

        transform.DOKill();

        // Hardcoded wait so particles can play before the animation begins
        float wait = 1.5f;

        DOVirtual.DelayedCall(wait, () =>
        {
            Sequence s = DOTween.Sequence();

            s.Append(transform.DOScale(_initialScale * 1.15f, 0.15f))
                .Append(transform.DOScale(_initialScale * 0.85f, 0.15f))
                .Append(transform.DOScale(_initialScale * 1.10f, 0.15f))
                .Append(transform.DOScale(Vector3.zero, 0.25f))
                .OnComplete(() => OnCompleteSequence());
        });

        void OnCompleteSequence()
        {
            gameObject.SetActive(false); 
            onCompletedWeld.Invoke();
        }
    }

    public void NotifyPointActivated()
    {
        _activated++;
        UpdateUI();

        if (_activated >= _points.Length)
            FullyWeldedEffect();
    }
}