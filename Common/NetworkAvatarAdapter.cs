using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAvatarAdapter : BaseAvatarAdapter
{
    [SerializeField]
    public SyncClientData ClientData;
    [SerializeField]
    public bool IsPlayable = false;
}
