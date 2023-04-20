using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Pool;

public class HitComponent : MonoBehaviour
{
    public PlayerAttackEffect Effect;

    public CameraEffect CamEffect;

    private ObjectPool<PlayerAttackEffect> _playerAttackEffectPool;

    private void Awake()
    {
        _playerAttackEffectPool = new ObjectPool<PlayerAttackEffect>(GeneratePlayerAttackEffect);
    }

    PlayerAttackEffect GetPlayerAttackEffectFromPool(Vector3 point)
    {
        PlayerAttackEffect effect = _playerAttackEffectPool.Get();
        effect.transform.position = point;
        effect.gameObject.SetActive(true);
        return effect;
    }

    PlayerAttackEffect GeneratePlayerAttackEffect()
    {
        PlayerAttackEffect effect = Instantiate(Effect);
        effect.Pool = _playerAttackEffectPool;
        return effect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagLiteral.MONSTER))
        {
            Bounds bounds = collision.bounds;
            Vector3 point = bounds.center;
            CamEffect.PlayScreenShake();
            GetPlayerAttackEffectFromPool(point);
        }
    }
}
