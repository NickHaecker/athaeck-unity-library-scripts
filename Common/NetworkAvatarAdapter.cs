using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SyncClientData
{
    public string ID;
    public float[] Position;
    public float[] Rotation;
    public string Scene;
    public string[] Abilitys;
}

public class NetworkAvatarAdapter : BaseAvatarAdapter
{
    [SerializeField]
    public SyncClientData ClientData;
    [SerializeField]
    public bool IsPlayable = false;
}
