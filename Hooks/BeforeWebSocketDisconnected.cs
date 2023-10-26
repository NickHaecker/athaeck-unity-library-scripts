using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public interface BeforeWebSocketDisconnected
{
    public void OnBeforeWebSocketDisconnected(WebSocket webSocket);
}
