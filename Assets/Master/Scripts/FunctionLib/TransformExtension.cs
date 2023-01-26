using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    public static void Rotate2DGameObject(this Transform transformContext, Vector3 direction)
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion cRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transformContext.rotation = cRotation;
    }
}
