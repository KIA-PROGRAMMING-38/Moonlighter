using Enums;
using UnityEngine;

public class PlayerCharacter : Character
{
    public CharacterStatData Stat
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
    public FacingDirection PlayerFacingDirection { get; private set; }

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
        PlayerFacingDirection = FacingDirection.Down;
    }

    public void SetFacingDirection()
    {
        int DirX = Mathf.RoundToInt(Anim.GetFloat(PlayerAnimParameters.MoveX));
        int DirY = Mathf.RoundToInt(Anim.GetFloat(PlayerAnimParameters.MoveY));
        if(DirY > 0)
        {
            PlayerFacingDirection = FacingDirection.Up;
        }
        else if(DirY < 0)
        {
            PlayerFacingDirection = FacingDirection.Down;
        }
        else
        {
            if(DirX > 0)
            {
                PlayerFacingDirection = FacingDirection.Right;
            }
            else if(DirX < 0)
            {
                PlayerFacingDirection = FacingDirection.Left;
            }
        }
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