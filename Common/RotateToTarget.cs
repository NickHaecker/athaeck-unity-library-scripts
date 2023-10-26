using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RotationEventCallback(Quaternion roation);
public class RotateToTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateTo(GameObject target,RotationEventCallback rotationEventCallback = null)
    {
        Quaternion rotation = Utils.RotateToTarget(target, transform);

        if(rotationEventCallback != null)
        {
            rotationEventCallback(rotation);
        }
    }

}
