using DG.Tweening;
using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected CharacterStat stat = new CharacterStat();
    protected int curHp;
    protected SpriteRenderer sr;
    
    private IEnumerator _onDamagedTween;
    private Material _originMaterial;
    private Material _hitMaterial;
    private float _hitTweenDuration = 0.35f;
    private bool _isHitTweening;

    protected virtual void Awake()
    {
        sr = transform.Find(ObjectLiteral.Body).GetComponent<SpriteRenderer>();
        _originMaterial = sr.material;
        _hitMaterial = Managers.Resource.Load<Material>(PathLiteral.HitMaterial);
        _onDamagedTween = OnDamagedTween();
    }

    private void OnEnable()
    {
        curHp = stat.MaxHp;
    }

    public abstract void Attack();

    public virtual void OnDamaged(int damage)
    {
        if(false == _isHitTweening)
        {
            StartCoroutine(_onDamagedTween);
        }
        int trueDamage = damage - stat.Def;
        if(trueDamage <= 0)
        {
            trueDamage = 1;
        }

        curHp -= trueDamage;
        if(curHp <= 0)
        {
            curHp = 0;
            Die();
        }
    }

    private IEnumerator OnDamagedTween()
    {
        while (true)
        {
            _isHitTweening = true;
            sr.material = _hitMaterial;
            yield return WaitForSecondsCache.GetWaitForSeconds(_hitTweenDuration);
            sr.material = _originMaterial;
            _isHitTweening = false;
            StopCoroutine(_onDamagedTween);
            yield return null;
        }
    }

    public abstract void Die();
}