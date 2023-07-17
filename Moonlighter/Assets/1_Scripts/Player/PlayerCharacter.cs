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
    
    public Animator Anim { get; private set; }
    public Rigidbody2D Rigid { get; private set; }
    
    public FacingDirection PlayerFacingDirection { get; private set; }

    public Weapon CurrentWeapon { get; private set; }

    public bool CanAttack;

    private FacingDirection[,] _facingDirections =
    {
        {FacingDirection.Down, FacingDirection.Down, FacingDirection.Down },
        {FacingDirection.Left, FacingDirection.Down, FacingDirection.Right },
        {FacingDirection.Up, FacingDirection.Up, FacingDirection.Up }
    };

    protected override void Awake()
    {
        base.Awake();
        stat = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.Player];
        Anim = transform.Find(ObjectLiteral.Body).GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();

        Transform WeaponPosition = transform.Find("Weapon");
        CurrentWeapon = Managers.Resource.Instantiate("TrainShortSword", WeaponPosition).GetComponent<Weapon>();
        CurrentWeapon.Init(WeaponId.TrainShortSword);

        CanAttack = true;
    }

    private void Start()
    {
        Anim.SetBool(PlayerAnimParameters.Idle, true);
        Anim.SetFloat(PlayerAnimParameters.MoveY, -1);
        PlayerFacingDirection = FacingDirection.Down;
    }

    public void SetFacingDirection()
    {
        int dirX = 1 + Mathf.RoundToInt(Anim.GetFloat(PlayerAnimParameters.MoveX));
        int dirY = 1 + Mathf.RoundToInt(Anim.GetFloat(PlayerAnimParameters.MoveY));
        PlayerFacingDirection = _facingDirections[dirY, dirX];
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