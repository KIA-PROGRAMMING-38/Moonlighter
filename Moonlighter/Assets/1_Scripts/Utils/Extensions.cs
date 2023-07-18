using Enums;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomValue<T>(this T[] arr)
    {
        int randomIndex = Random.Range(0, arr.Length);

        return arr[randomIndex];
    }

    private static Vector2[] _directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    public static Vector2 ToVec2(this FacingDirection fd)
    {
        return _directions[(int)fd];
    }

    public static void SetMovementParameters(this Animator animator, int idx, int idy, Vector2 value)
    {
        animator.SetFloat(idx, value.x);
        animator.SetFloat(idy, value.y);
    }

    public static void SetMovementParameters(this Animator animator, int idx, int idy, float moveX, float moveY)
    {
        animator.SetFloat(idx, moveX);
        animator.SetFloat(idy, moveY);
    }

    public static void SetMovementParametersFromSource(this Animator animator, Animator source, int idx, int idy)
    {
        float moveX = source.GetFloat(idx);
        float moveY = source.GetFloat(idy);

        animator.SetMovementParameters(idx, idy, moveX, moveY);
    }

    public static void SetTriggerWithWeapon(this Animator animator, Animator weaponAnimator, int nextState)
    {
        animator.SetTrigger(nextState);
        weaponAnimator.SetTrigger(nextState);
    }
}
