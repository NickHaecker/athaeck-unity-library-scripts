using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public interface PassNetworkControllerState
{
    public void TakeWebSocket(BaseNetworkController networkController, bool connectionState);
}
