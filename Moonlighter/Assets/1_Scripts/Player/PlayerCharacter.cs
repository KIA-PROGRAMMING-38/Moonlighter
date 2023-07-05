using UnityEngine;
using Enums;

public class PlayerCharacter : Character
{
    public CharacterStat Stat
    {
        get
        {
            return stat;
        }
    }
    public PlayerInputHandler Input { get; private set; }
    
    public Animator Anim { get; private set; }
    public Rigidbody2D Rigid { get; private set; }
    public PlayerState PrevState;

    protected override void Awake()
    {
        base.Awake();
        stat = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.Player];
        Input = transform.GetComponent<PlayerInputHandler>();
        Anim = transform.Find(ObjectLiteral.Body).GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Anim.SetBool(PlayerAnimParameters.Idle, true);
        PrevState = PlayerState.Idle;
    }

    public override void Attack()
    {
        Debug.Log("Player Character Attack..!");
    }

    public override void Die()
    {
        Debug.Log("Player Character Die..");
    }
}