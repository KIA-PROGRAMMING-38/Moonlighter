using UnityEngine;

public static class EaseFunc
{
    public static float EaseOutCubic(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value--;
        end -= start;
        return end * (value * value * value + 1) + start;
    }

    public static Vector2 EaseOutCubic(Vector2 start, Vector2 end, float value)
    {
        Vector2 result = new Vector2();
        result.x = EaseOutCubic(start.x, end.x, value);
        result.y = EaseOutCubic(start.y, end.y, value);
        return result;
    }
}
