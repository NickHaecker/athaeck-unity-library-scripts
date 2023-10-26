using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseEndDelay
{
    public void OnStart();
    //public void OnStop();
    public void TakeDelayCallback(DelayFallback delayFallback);
}
