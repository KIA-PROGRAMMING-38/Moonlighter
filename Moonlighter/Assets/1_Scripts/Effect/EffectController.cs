using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class EffectController : MonoBehaviour
{
    private ObjectPool<GameObject> _pool;

    private SpriteRenderer _spriteRenderer;

    private Color _originColor = Color.white;
    private Vector3 _originScale = Vector3.one;
    private Quaternion _originRotation = Quaternion.Euler(Vector3.zero);

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _pool = Managers.Effect.EffectPool;
    }

    private void OnEnable()
    {
        SetOriginColor();

        transform.localScale = _originScale;
        transform.rotation = _originRotation;
    }

    private void DeactiveEffect()
    {
        _pool.Release(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void SetOriginColor()
    {
        _spriteRenderer.DOColor(_originColor, 0);
    }
}