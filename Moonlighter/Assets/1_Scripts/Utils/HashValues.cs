using UnityEngine;

public static class AnimationNameToHash
{
    public static readonly int RollEffect1 = Animator.StringToHash("RollEffect1");
    public static readonly int RollEffect2 = Animator.StringToHash("RollEffect2");
    public static readonly int RollEffect3 = Animator.StringToHash("RollEffect3");
    public static readonly int RollEffect4 = Animator.StringToHash("RollEffect4");
}

public static class AnimParameters
{
    public static readonly int MoveX = Animator.StringToHash("MoveX");
    public static readonly int MoveY = Animator.StringToHash("MoveY");
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Move = Animator.StringToHash("Move");
    public static readonly int Roll = Animator.StringToHash("Roll");
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int NormalAttack = Animator.StringToHash("NormalAttack");
    public static readonly int SpecialAttack = Animator.StringToHash("SpecialAttack");
}