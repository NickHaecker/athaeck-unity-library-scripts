using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AfterWebSocketDisconnected
{
   public void OnAfterWebSocketDisconnected(BaseNetworkController baseNetworkController);
}
