using UnityEngine;

public static class Utilits 
{
    public static float GetSqrDistance(Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }

    public static bool IsEnoughClose(Vector2 start, Vector2 end, float distance)
    {
        return GetSqrDistance(start, end) <= distance * distance;
    }
}
