using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCameraController : MonoBehaviour
{
    [SerializeField]
    protected Camera sceneCamera;
    [SerializeField]
    protected CinemachineBrain brain;

    protected Action SwitchTarget;



    private void Start()
    {

        SwitchTarget += OnSwitchTarget;
        OnStart();
    }
    protected virtual void OnStart()
    {

    }
    protected abstract void OnSwitchTarget();
    public Transform GetCamera()
    {
        return sceneCamera.transform;
    }

}
