using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleCameraController : BaseCameraController
{
    [SerializeField]
    protected CinemachineFreeLook baseCamera;
    [SerializeField]
    protected Transform target;

    protected override void OnSwitchTarget()
    {
        if (target == null)
        {
            return;
        }
        baseCamera.Follow = target;
        baseCamera.LookAt = target;
    }
}
