using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRemoteController : MonoBehaviour
{
    [SerializeField]
    protected List<BaseRemoteClient> connectedClients = new List<BaseRemoteClient>();
}
