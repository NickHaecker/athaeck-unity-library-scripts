using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Inspect
{
    public void OnInspect(bool state, CinemachineVirtualCamera virtualCamera, BaseAvatar character, BaseWatchable watchable);
}
