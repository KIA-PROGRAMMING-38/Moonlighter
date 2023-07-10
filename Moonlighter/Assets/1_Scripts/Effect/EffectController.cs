using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class EffectController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Color _originColor = Color.white;
    private Vector3 _originScale = Vector3.one;
    private Quaternion _originRotation = Quaternion.Euler(Vector3.zero);

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _spriteRenderer.DOColor(_originColor, 0);

        transform.localScale = _originScale;
        transform.rotation = _originRotation;
    }

    private void DeactiveEffect()
    {
        Managers.Effect.ReleaseToPool(this);
        this.gameObject.SetActive(false);
    }

    public void FadeOut(float alpha, float duration) => _spriteRenderer.DOFade(alpha, duration);

    public void RotateEffect(Vector3 endRotationValue, float duration, RotateMode mode) => transform.DORotate(endRotationValue, duration, mode);
}