using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterPresenter MonsterPresenter { get; private set; }

    private IEnumerator _OnHitCoroutine;
    private IEnumerator _OnDieCoroutine;

    [SerializeField]
    private Potion _item;

    private bool _isRunningHitEvent = false;
    private float _hitTweenTime = 0.3f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigid;
    public Animator Anim { get; private set; }

    [SerializeField]
    protected MonsterData monsterData;

    [SerializeField]
    private Material _hitMaterial;
    private Material _originMaterial;

    public bool IsHit { get; private set; }
    public bool IsDie { get; private set; }

    public virtual void Awake()
    {
        MonsterPresenter = new MonsterPresenter();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        _originMaterial = _spriteRenderer.material;
        
    }

    public virtual void OnEnable()
    {
        IsDie = false;
        monsterData.CurHp = monsterData.Maxhp;
        _spriteRenderer.material = _originMaterial;
        _OnHitCoroutine = OnHitState();
        _OnDieCoroutine = OnDieState();
    }

    public int GetNormalDamageValue()
    {
        return monsterData.NormalDamage;
    }

    private void OnHit()
    {
        if(false == _isRunningHitEvent && false == IsDie)
        {
            StartCoroutine(_OnHitCoroutine);
        }
    }

    public void GetDamaged(int damage)
    {
        monsterData.CurHp -= damage;
        if(monsterData.CurHp <= 0)
        {
            IsDie = true;
            monsterData.CurHp = 0;
            _spriteRenderer.material = _hitMaterial;
            Anim.SetTrigger(MonsterAnimParamsToHash.DIE);
            StartCoroutine(_OnDieCoroutine);
        }
    }


    IEnumerator OnHitState()
    {
        while (true)
        {
            IsHit = true;
            _isRunningHitEvent = true;
            _spriteRenderer.material = _hitMaterial;
            yield return TimeStore.GetWaitForSeconds(_hitTweenTime);
            if(false == IsDie)
            {
                _spriteRenderer.material = _originMaterial;
            }
            _isRunningHitEvent = false;
            IsHit = false;
            StopCoroutine(_OnHitCoroutine);
            yield return null;
        }
    }

    IEnumerator OnDieState()
    {
        while(true)
        {
            yield return TimeStore.GetWaitForSeconds(0.667f);
            StopCoroutine(_OnDieCoroutine);
            gameObject.SetActive(false);
            Instantiate(_item, this.transform.position, Quaternion.identity);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagLiteral.PLAYER_WEAPON))
        {
            SpriteRenderer weaponSprite = other.transform.parent.GetComponent<SpriteRenderer>();
            Weapon playerWeapon = other.transform.parent.GetComponent<Weapon>();
            GetDamaged(playerWeapon.GetDamageValue());
            MonsterPresenter.ModifyMonsterHPRatio(monsterData.Maxhp, monsterData.CurHp);
            OnHit();
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(((Vector2)_spriteRenderer.bounds.center - (Vector2)weaponSprite.bounds.center).normalized * 0.5f, ForceMode2D.Impulse);
        }
    }
}
