using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PassNetworkController
{
    public void TakeBaseNetworkController(BaseNetworkController baseNetworkController);
    public void RemoveBaseNetworkController(BaseNetworkController baseNetworkController);
}
