using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterStatData Stat { get; protected set; }
    protected SpriteRenderer sr;
    protected int curHp;

    public Rigidbody2D Rigid { get; private set; }
    public Animator Anim { get; private set; }
    
    private IEnumerator _onDamagedTween;
    private Material _originMaterial;
    private Material _hitMaterial;
    private float _hitTweenDuration = 0.35f;
    private bool _isHitTweening;

    protected virtual void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Anim = transform.Find("Body").GetComponent<Animator>();
        sr = transform.Find("Body").GetComponent<SpriteRenderer>();
        _originMaterial = sr.material;
        _hitMaterial = Managers.Resource.MaterialTable.Load(PathLiteral.HitMaterial);
        _onDamagedTween = OnDamagedTween();
    }

    private void OnEnable()
    {
        curHp = Stat.MaxHp;
    }

    public virtual void OnDamaged(int damage)
    {
        if(false == _isHitTweening)
        {
            StartCoroutine(_onDamagedTween);
        }
        int trueDamage = damage - Stat.Def;
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