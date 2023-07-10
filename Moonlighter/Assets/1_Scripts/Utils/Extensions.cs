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
}
