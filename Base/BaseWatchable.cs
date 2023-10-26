using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWatchable : MonoBehaviour
{
    [SerializeField]
    protected GameObject looktAt;
    [SerializeField]
    protected GameObject lookAtPosition;

    [SerializeField]
    protected bool isInUse = false;

    public GameObject GetLooktAtPosition()
    {
        return lookAtPosition;
    }

    public GameObject GetLookAt()
    {
        return looktAt;
    }

    public bool GetIsInUse()
    {
        return isInUse;
    }
    public bool LookAt()
    {
        return TryGetComponent<BasePointOfInterest>(out BasePointOfInterest component);
    }

    public abstract string GetIsInUseWith();

    public abstract void OnInspect(bool state, CinemachineVirtualCamera virtualCamera, BaseAvatar character, BaseWatchable baseWatchable);
}
