using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SyncAnimationSetFloat
{
    public string Client;
    public string Type;
    public float Value;
}
[Serializable]
public struct SyncAnimationSetBool
{
    public string Client;
    public string Type;
    public bool Value;
}
[Serializable]
public struct SyncAnimationSetTrigger
{
    public string Client;
    public string Type;
    public bool Value;
}
[Serializable]
public struct SyncAnimationResetTrigger
{
    public string Client;
    public string Type;
    public bool Value;
}
