using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public AudioSource MonsterAudioSource;

    public MonsterHealthBar MonsterHealthBar;

    public AudioClip HitSound;

    public MonsterPresenter MonsterPresenter { get; private set; }

    private IEnumerator _OnHitCoroutine;
    private IEnumerator _OnDieCoroutine;

    [SerializeField]
    private Potion _item;

    private bool _isRunningHitEvent = false;
    private float _hitTweenTime = 0.3f;
    protected SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigid;
    public Animator Anim { get; private set; }

    [SerializeField]
    protected MonsterData monsterData;

    [SerializeField]
    private Material _hitMaterial;
    protected Material _originMaterial;

    public bool IsHit { get; private set; }
    public bool IsDie { get; private set; }

    public int CurrentHp;

    public virtual void Awake()
    {
        MonsterAudioSource = GetComponent<AudioSource>();
        MonsterPresenter = new MonsterPresenter();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        _originMaterial = _spriteRenderer.material;
    }

    private void Start()
    {
        if(MonsterHealthBar != null)
        {
            MonsterHealthBar.Initialized();
        }
    }

    public virtual void OnEnable()
    {
        IsDie = false;
        CurrentHp = monsterData.Maxhp;
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
        CurrentHp -= damage;
        if(CurrentHp <= 0)
        {
            IsDie = true;
            StopCoroutine(_OnHitCoroutine);
            CurrentHp = 0;
            _spriteRenderer.material = _hitMaterial;
            Anim.SetTrigger(MonsterAnimParamsToHash.DIE);
            if(monsterData.MonsterType == EnumValue.MonsterType.Normal)
            {
                StartCoroutine(_OnDieCoroutine);
            }
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
            MonsterPresenter.ModifyMonsterHPRatio(monsterData.Maxhp, CurrentHp);
            MonsterAudioSource.PlayOneShot(HitSound);
            OnHit();
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(((Vector2)_spriteRenderer.bounds.center - (Vector2)weaponSprite.bounds.center).normalized * 0.5f, ForceMode2D.Impulse);
        }
    }
}
