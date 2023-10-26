using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRemoteClient
{
    protected GameObject remoteObject;
    public abstract void TakeGameObject(GameObject gameObject);
    public abstract GameObject GetRemoteObject();
}
