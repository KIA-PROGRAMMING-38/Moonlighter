using EnumValue;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator Anim { get; set; }
    public Rigidbody2D Rigid { get; private set; }
    public CapsuleCollider2D PlayerCollider { get; private set; }
    public SpriteRenderer PlayerSpriteRenderer { get; private set; }
    private Material _originMaterial;
    [SerializeField]
    private Material _hitMaterial;


    [SerializeField]
    private PlayerData _playerData;

    public AnimationHandler AnimHandler { get; private set; }

    public PlayerStates CurrentState { get; set; }
    public PlayerStates PrevState { get; set; }

    public Weapons CurrentPrimaryWeapon { get; set; }

    public Transform[] MonsterDestinationPos;

    private IEnumerator _OnHitCoroutine;
    public bool _isRunningHitEvent = false;
    private float _tweenTime = 0.3f;

    private IEnumerator _OnInvincibleCoroutine;
    private bool _isInvincible = false;
    private float _invincivleTime = 0.7f;
    private float _tweenCount;
    private Color _originColor;

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
        _originMaterial = PlayerSpriteRenderer.material;
        _originColor = PlayerSpriteRenderer.color;
        CurrentPrimaryWeapon = Weapons.BigSword;
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

    IEnumerator OnHitState()
    {
        while (true)
        {
            _isRunningHitEvent = true;
            PlayerSpriteRenderer.material = _hitMaterial;
            yield return TimeStore.GetWaitForSeconds(_tweenTime);
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
            _isInvincible = true;
            PlayerCollider.enabled = false;
            ++_tweenCount;
            Color color = _originColor;
            color.a = 0f;
            PlayerSpriteRenderer.color = color;
            yield return TimeStore.GetWaitForSeconds(0.15f);
            PlayerSpriteRenderer.color = _originColor;
            if (_tweenCount == 3)
            {
                _tweenCount = 0;
                _isInvincible = false;
                PlayerCollider.enabled = true;
                StopCoroutine(_OnInvincibleCoroutine);
            }
            yield return TimeStore.GetWaitForSeconds(0.15f); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagLiteral.MONSTER_PROJECTILE) || other.CompareTag(TagLiteral.MONSTER_MELEEATTACK) || other.CompareTag(TagLiteral.BOSS_STONEARM_STAMP) || other.CompareTag(TagLiteral.BOSS_ROCKETARM_PUNCH))
        {
            if (false == _isInvincible)
            {
                OnHit();
            }
        }

        if (other.CompareTag(TagLiteral.BOSS_WAVE))
        {
            Rigid.AddForce((transform.position - other.transform.position).normalized * 100f, ForceMode2D.Impulse);
        }

        if (other.CompareTag(TagLiteral.MONSTER_CONTACTATTACK))
        {
            CircleCollider2D collider = other.GetComponent<CircleCollider2D>();
            if (collider != null)
            {
                Vector2 contactPoint = other.ClosestPoint(this.Rigid.position);
                Vector2 knockBack = (contactPoint - this.Rigid.position).normalized;
                Debug.Log(knockBack);
                other.transform.root.GetComponent<Rigidbody2D>().AddForce(knockBack * 300f, ForceMode2D.Force);
            }

            OnHit();
        }
    }
}
