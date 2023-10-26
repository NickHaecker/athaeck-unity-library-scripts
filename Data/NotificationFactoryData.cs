using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotificationFactoryData", menuName = "Data/Notification/Factory")]
[Serializable]
public class NotificationFactoryData : ScriptableObject
{
    public string BasePath = "Notification/";
}
