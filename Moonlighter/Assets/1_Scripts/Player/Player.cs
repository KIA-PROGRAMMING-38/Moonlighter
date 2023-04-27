using EnumValue;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region BaseComponent
    public Animator Anim { get; set; }
    public Rigidbody2D Rigid { get; private set; }
    public CapsuleCollider2D PlayerCollider { get; private set; }
    public SpriteRenderer PlayerSpriteRenderer { get; private set; }

    #endregion

    #region Hit Component
    private Material _originMaterial;
    [SerializeField]
    private Material _hitMaterial;

    private IEnumerator _OnHitCoroutine;
    private bool _isRunningHitEvent = false;
    private float _hitTweenTime = 0.3f;

    private IEnumerator _OnDecreasePlayerHp;

    private IEnumerator _OnInvincibleCoroutine;
    private bool _isInvincible = false;
    private float _invincivleTweenTime = 0.1f;
    private int _invincibleTweenCount;
    private Color _originColor;
    private Color _invincibleColor;

    #endregion


    [SerializeField]
    private PlayerData _playerData;

    public AnimationHandler AnimHandler { get; private set; }

    public PlayerStates CurrentState { get; set; }
    public PlayerStates PrevState { get; set; }

    public Weapons PrimaryWeapon { get; set; }
    public Weapons SecondaryWeapon { get; set; }

    public Transform[] MonsterDestinationPos;

    public PlayerData PlayerData
    {
        get
        {
            return _playerData;
        }
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        PlayerCollider = GetComponent<CapsuleCollider2D>();
        Rigid = GetComponent<Rigidbody2D>();
        AnimHandler = GetComponent<AnimationHandler>();
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        _playerData.CurHp = _playerData.MaxHp;
        
        _originMaterial = PlayerSpriteRenderer.material;
        PrimaryWeapon = Weapons.BigSword;
        SecondaryWeapon = Weapons.ShortSwordAndShield;
        _originColor = PlayerSpriteRenderer.color;
        _invincibleColor = PlayerSpriteRenderer.color;
        _invincibleColor.a = 0f;
    }

    private void Start()
    {
        Anim.SetBool(PlayerAnimParamsToHash.IDLE, true);
        _OnHitCoroutine = OnHitState();
        _OnInvincibleCoroutine = OnInvincibleState();
    }

    private void SetRollInvincible()
    {
        PlayerCollider.enabled = false;
    }

    private void SetRollInvincibleFalse()
    {
        PlayerCollider.enabled = true;
    }

    private void OnHit()
    {
        if (false == _isRunningHitEvent)
        {
            StartCoroutine(_OnHitCoroutine);
        }
    }

    private void GetDamaged(int damage)
    {
        _playerData.CurHp -= damage;
        if(_playerData.CurHp < 0)
        {
            _playerData.CurHp = 0;
        }
    }

    IEnumerator OnHitState()
    {
        while (true)
        {
            _isRunningHitEvent = true;
            PlayerSpriteRenderer.material = _hitMaterial;
            float t = 0;
            while(t < _hitTweenTime)
            {
                t += Time.deltaTime;
                float sinVal = Mathf.Sin(Mathf.Lerp(0, Mathf.PI, t / _hitTweenTime));
                _hitMaterial.SetFloat(ShaderPropertyToHash.HIT_BLEND, sinVal);
                yield return null;
            }
            PlayerSpriteRenderer.material = _originMaterial;
            StartCoroutine(_OnInvincibleCoroutine);
            StopCoroutine(_OnHitCoroutine);
            _isRunningHitEvent = false;
            yield return null;
        }
    }

    IEnumerator OnInvincibleState()
    {
        while (true)
        {
            ++_invincibleTweenCount;
            _isInvincible = true;
            PlayerCollider.enabled = false;
            PlayerSpriteRenderer.color = _invincibleColor;
            yield return TimeStore.GetWaitForSeconds(_invincivleTweenTime);
            PlayerSpriteRenderer.color = _originColor;
            if(_invincibleTweenCount == 2)
            {
                _invincibleTweenCount = 0;
                PlayerCollider.enabled = true;
                _isInvincible = false;
                StopCoroutine(_OnInvincibleCoroutine);
            }

            yield return TimeStore.GetWaitForSeconds(_invincivleTweenTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagLiteral.MONSTER_PROJECTILE) || other.CompareTag(TagLiteral.MONSTER_MELEEATTACK) || other.CompareTag(TagLiteral.BOSS_STONEARM_STAMP) || other.CompareTag(TagLiteral.BOSS_ROCKETARM_PUNCH))
        {
            Monster monster = other.transform.root.GetComponent<Monster>();

            if (false == _isInvincible)
            {
                GetDamaged(monster.GetNormalDamageValue());
                PlayerPresenter.ModifyPlayerHPRatio(_playerData.MaxHp, _playerData.CurHp);
                OnHit();
            }
        }

        if (other.CompareTag(TagLiteral.BOSS_WAVE))
        {
            if (false == _isInvincible)
            {
                Rigid.AddForce((transform.position - other.transform.position).normalized * 100f, ForceMode2D.Impulse);
                OnHit();
            }
        }

        if (other.CompareTag(TagLiteral.MONSTER_CONTACTATTACK))
        {
            if(false == _isInvincible)
            {
                CircleCollider2D collider = other.GetComponent<CircleCollider2D>();
                if (collider != null)
                {
                    Vector2 contactPoint = other.ClosestPoint(this.Rigid.position);
                    Vector2 knockBack = (contactPoint - this.Rigid.position).normalized;
                    other.transform.root.GetComponent<Rigidbody2D>().AddForce(knockBack * 5f, ForceMode2D.Impulse);
                }
                Monster monster = other.transform.root.GetComponent<Monster>();
                GetDamaged(monster.GetNormalDamageValue());
                PlayerPresenter.ModifyPlayerHPRatio(_playerData.MaxHp, _playerData.CurHp);
                OnHit();
            }
        }
    }
}
