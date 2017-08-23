using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMath {

	public static bool CompareVector3(Vector3 a, Vector3 b)
    {
        return (a.x == b.x && a.y == b.y && a.z == b.z);
    }
    public static bool CompareVector3XY(Vector3 a, Vector3 b)
    {
        return (a.x == b.x && a.y == b.y);
    }
    public static bool CompareVector2(Vector2 a, Vector2 b)
    {
        return (a.x == b.x && a.y == b.y);
    }
}
