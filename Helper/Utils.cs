using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Quaternion RotateToTarget(GameObject targetObject,Transform currentObject)
    {
        BoxCollider col = targetObject.GetComponent<BoxCollider>();
        Vector3 dir = col.ClosestPoint(currentObject.position);
        dir.y = currentObject.position.y;
        Vector3 forward = (dir - currentObject.position).normalized;
        return Quaternion.LookRotation(forward);
    }
}
