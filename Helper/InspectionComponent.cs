using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void InspectionCallback(bool state, CinemachineVirtualCamera cinemachineVirtualCamera, BaseAvatar baseCharacter, BaseWatchable baseWatchable);
public interface InspectionComponent
{
    public void PassInspectionCallback(InspectionCallback inspectionCallback);
    public void RemoveInspectionCallback(InspectionCallback inspectionCallback);


}
