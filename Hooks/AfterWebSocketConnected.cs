using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public interface AfterWebSocketConnected
{
    public void OnAfterWebSocketConnected(WebSocket webSocket);
}
