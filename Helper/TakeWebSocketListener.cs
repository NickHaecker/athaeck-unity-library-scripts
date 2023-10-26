using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TakeWebSocketListener
{
    public void TakeWebSocketListener(WebSocketListener webSocketListener);
    public void RemoveWebSocketListener(WebSocketListener webSocketListener);
}
public delegate void SocketListener(ReceivedEvent receivedEvent);
[Serializable]
public class WebSocketListener
{
    public string Key;
    public SocketListener SocketListener;
}

