using UnityEngine;

public static class Bezier
{
    public static Vector3 First(Vector3 p0, Vector3 p1, float t)
    {
        return Vector3.Lerp(p0, p1, t);
    }

    public static Vector3 Second(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 m0 = First(p0, p1, t);
        Vector3 m1 = First(p1, p2, t);
        return First(m0, m1, t);
    }
}
