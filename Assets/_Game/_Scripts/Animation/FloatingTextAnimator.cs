using UnityEngine;
using DG.Tweening;

/// <summary>
/// Spins the text around the Y axis and animates a smooth vertical float motion.
/// Uses DOTween for clean, allocation-free tweening.
/// </summary>
public class FloatingTextAnimator : MonoBehaviour
{
    [SerializeField] float rotationTime = .5f;
    [SerializeField] float floatHeight = 0.25f;
    [SerializeField] float floatDuration = 1.6f;

    Tween _floatTween;
    Tween _rotationTween;

    void Awake()
    {
        AnimateRotation();
        AnimateFloating();
    }

    void AnimateRotation()
    {
        _rotationTween = transform
            .DORotate(new Vector3(0f, 360f, 0f), rotationTime, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }

    void AnimateFloating()
    {
        Vector3 startPos = transform.localPosition;

        _floatTween = transform
            .DOLocalMoveY(startPos.y + floatHeight, floatDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void OnDestroy()
    {
        _floatTween?.Kill();
        _rotationTween?.Kill();
    }
}