using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private IEnumerator _OnHitCoroutine;
    private bool _isRunningHitEvent = false;
    private float _hitTweenTime = 0.3f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigid;
    [SerializeField]
    protected MonsterData monsterData;

    [SerializeField]
    private Material _hitMaterial;
    private Material _originMaterial;

    public bool IsHit { get; private set; }

    public virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        _originMaterial = _spriteRenderer.material;
        _OnHitCoroutine = OnHitState();
    }

    public int GetNormalDamageValue()
    {
        return monsterData.NormalDamage;
    }

    private void OnHit()
    {
        if(false == _isRunningHitEvent)
        {
            StartCoroutine(_OnHitCoroutine);
        }
    }

    public void GetDamaged(int damage)
    {
        monsterData.CurHp -= damage;
        if(monsterData.CurHp < 0)
        {
            monsterData.CurHp = 0;
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
            _spriteRenderer.material = _originMaterial;
            _isRunningHitEvent = false;
            IsHit = false;
            StopCoroutine(_OnHitCoroutine);
            yield return null;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagLiteral.PLAYER_WEAPON))
        {
            SpriteRenderer weaponSprite = other.transform.parent.GetComponent<SpriteRenderer>();
            Weapon playerWeapon = other.transform.parent.GetComponent<Weapon>();
            GetDamaged(playerWeapon.GetDamageValue());
            MonsterPresenter.ModifyPlayerHPRatio(monsterData.Maxhp, monsterData.CurHp);
            OnHit();
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(((Vector2)_spriteRenderer.bounds.center - (Vector2)weaponSprite.bounds.center).normalized * 0.5f, ForceMode2D.Impulse);
        }
    }
}