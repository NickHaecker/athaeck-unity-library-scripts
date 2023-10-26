using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PassNetworkSynchronizer
{
    public void TakeBaseNetworkSynchronizer(BaseNetworkSynchronizer networkSynchronizer);
    public void RemoveBaseNetworkSynchronizer(BaseNetworkSynchronizer networkSynchronizer);
}
