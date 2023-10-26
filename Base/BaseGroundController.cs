using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGroundController : MonoBehaviour, BeforeSceneStart
{
    [SerializeField]
    protected GameObject spawn;

    public Action<GameObject> TakeSpawn;

    public void OnBeforeSceneStart(BaseSceneController baseSceneController)
    {
        foreach (PassGroundController passGround in baseSceneController.GetComponentsInChildren<PassGroundController>(true))
        {
            passGround.TakeGroundController(this);
        }
        TakeSpawn?.Invoke(spawn);
    }
}
