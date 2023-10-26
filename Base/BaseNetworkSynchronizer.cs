using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public abstract class BaseNetworkSynchronizer : MonoBehaviour, PassNetworkControllerState, TakeWebSocketListener
{
    [SerializeField]
    protected WebSocket webSocket;
    [SerializeField]
    private List<WebSocketListener> _webSocketListener = new List<WebSocketListener>();

    public void TakeWebSocket(BaseNetworkController networkController, bool connectionState)
    {
        NetworkController n = networkController as NetworkController;
        if (connectionState)
        {
            ConnectToWebSocket(n);
        }
        else
        {
            DisconnectFromWebSocket(n);
        }
        foreach (PassNetworkSynchronizer networkSynchronizer in GetComponents<PassNetworkSynchronizer>())
        {
            if (connectionState)
            {
                networkSynchronizer.TakeBaseNetworkSynchronizer(this);
            }
            else
            {
                networkSynchronizer.RemoveBaseNetworkSynchronizer(this);
            }
        }
    }
    protected virtual void ConnectToWebSocket(NetworkController networkController)
    {
        webSocket = networkController.GetSocket();
        networkController.TakeEvent += OnTakeEvent;
        foreach (TakeEvent takeEvent in GetComponents<TakeEvent>())
        {
            networkController.TakeEvent += takeEvent.OnTakeEvent;
        }

    }
    protected virtual void DisconnectFromWebSocket(NetworkController networkController)
    {
        webSocket = null;
        networkController.TakeEvent -= OnTakeEvent;
        foreach (TakeEvent takeEvent in GetComponents<TakeEvent>())
        {
            networkController.TakeEvent -= takeEvent.OnTakeEvent;
        }
    }

    public void Synchronize(SendEvent eventToSynchronize)
    {
        webSocket.Send(eventToSynchronize.ToJson());
    }
    private void OnTakeEvent(ReceivedEvent receivedEvent)
    {
        foreach (WebSocketListener listener in _webSocketListener)
        {
            if (receivedEvent.eventName == listener.Key)
            {
                listener.SocketListener(receivedEvent);
            }
        }
    }

    public void TakeWebSocketListener(WebSocketListener webSocketListener)
    {
        _webSocketListener.Add(webSocketListener);
    }

    public void RemoveWebSocketListener(WebSocketListener webSocketListener)
    {
        _webSocketListener.Remove(webSocketListener);
    }
}
