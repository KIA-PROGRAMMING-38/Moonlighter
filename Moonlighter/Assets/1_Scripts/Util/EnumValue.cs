namespace EnumValue
{
    public enum PlayerStates
    {
        Idle,
        Move,
        Roll,
        ComboAttackOne,
        ComboAttackTwo,
        ComboAttackThree,
        ReadySecondaryAction,
        OnSecondaryAction,
        SecondaryAction
    }

    public enum WeaponAttackDir
    {
        Down,
        Left,
        Right,
        Up,
    }

    public enum Weapons
    {
        ShortSwordAndShield,
        BigSword
    }

    public enum GolemTurretFirePositions
    {
        Down,
        Left,
        Right,
        Up
    }

    public enum GolemSoldierDirection
    {
        Down,
        Left,
        Right,
        Up
    }

    public enum BossAttackAction
    {
        Wave,
        StoneArmPunch,
        StoneArmStamp,
        StickyArmAction
    }

    public enum ItemType
    {
        Empty,
        Potion,
        Weapon
    }
}