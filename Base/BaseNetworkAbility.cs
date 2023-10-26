using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNetworkAbility : BaseAbility, PassNetworkSynchronizer
{
    protected Action<SendEvent> SendEvent;
    [SerializeField]
    protected List<WebSocketListener> webSocketListener = new List<WebSocketListener>();
    public void TakeBaseNetworkSynchronizer(BaseNetworkSynchronizer networkSynchronizer)
    {
        NetworkSynchronizer synchronizer = networkSynchronizer as NetworkSynchronizer;
        SendEvent += synchronizer.Synchronize;
        InitNetworkSynchronizer(synchronizer);
    }
    protected virtual void InitNetworkSynchronizer(BaseNetworkSynchronizer networkSynchronizer)
    {
        TakeWebSocketListener takeWebSocketListener = networkSynchronizer;
        foreach(WebSocketListener listener in webSocketListener)
        {
            takeWebSocketListener.TakeWebSocketListener(listener);
        }
    }

    public void RemoveBaseNetworkSynchronizer(BaseNetworkSynchronizer networkSynchronizer)
    {   
        NetworkSynchronizer synchronizer = networkSynchronizer as NetworkSynchronizer;
        RemoveBaseNetworkSynchronizer(synchronizer);
        SendEvent -= synchronizer.Synchronize;
    }
    protected virtual void RemoveNetworkSynchronizer(NetworkSynchronizer networkSynchronizer)
    {
        TakeWebSocketListener takeWebSocketListener = networkSynchronizer;
        foreach (WebSocketListener listener in webSocketListener)
        {
            takeWebSocketListener.RemoveWebSocketListener(listener);
        }
    }
}
