using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotificationData", menuName = "Data/Notification/Data")]
[Serializable]
public class NotificatioData : ScriptableObject
{
    public NotificationType Type;
    public string Notification;
}
public enum NotificationType
{
    WARNING, ERROR, INFO
}