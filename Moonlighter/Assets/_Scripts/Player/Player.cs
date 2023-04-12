using EnumValue;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator Anim { get; set; }
    public Rigidbody2D Rigid { get; private set; }
    public CapsuleCollider2D PlayerCollider { get; private set; }

    [SerializeField]
    private PlayerData _playerData;


    public AnimationHandler AnimHandler { get; private set; }

    public PlayerStates CurrentState { get; set; }
    public PlayerStates PrevState { get; set; }

    public Weapons CurrentPrimaryWeapon { get; set; }

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
        CurrentPrimaryWeapon = Weapons.BigSword;
    }

    private void Start()
    {
        Anim.SetBool("Idle", true);
        
    }

    private void SetRollInvincible()
    {
        PlayerCollider.enabled = false;
    }

    private void SetRollInvincibleFalse()
    {
        PlayerCollider.enabled = true;
    }
}
