using Enums;
using UnityEngine;

public class PlayerCharacter : Character
{
    public static PlayerCharacter Instance;
    
    public FacingDirection PlayerFacingDirection { get; private set; }

    public Weapon CurrentWeapon { get; private set; }

    private FacingDirection[,] _facingDirections =
    {
        {FacingDirection.Down, FacingDirection.Down, FacingDirection.Down },
        {FacingDirection.Left, FacingDirection.Down, FacingDirection.Right },
        {FacingDirection.Up, FacingDirection.Up, FacingDirection.Up }
    };

    protected override void Awake()
    {
        base.Awake();
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        Stat = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.Player];

        Transform WeaponPosition = transform.Find("Weapon");
        CurrentWeapon = Managers.Resource.Instantiate("TrainShortSword", WeaponPosition).GetComponent<Weapon>();
        CurrentWeapon.Init(WeaponId.TrainShortSword);
    }

    private void Start()
    {
        Anim.SetBool(AnimParameters.Idle, true);
        Anim.SetFloat(AnimParameters.MoveY, -1);
        PlayerFacingDirection = FacingDirection.Down;
    }

    public void SetFacingDirection()
    {
        int dirX = 1 + Mathf.RoundToInt(Anim.GetFloat(AnimParameters.MoveX));
        int dirY = 1 + Mathf.RoundToInt(Anim.GetFloat(AnimParameters.MoveY));
        PlayerFacingDirection = _facingDirections[dirY, dirX];
    }

    public override void Die()
    {
        Debug.Log("Player Character Die..");
    }
}