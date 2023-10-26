using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NotificationFactory
{
    [SerializeField]
    private NotificationFactoryData _data;

    private T LoadScriptableObject<T>(string path) where T : ScriptableObject
    {
        return Resources.Load<T>(path);
    }

    public NotificatioData GetNotification(string name)
    {
        _data = LoadScriptableObject<NotificationFactoryData>("Notification/Factory/Data");

        return LoadScriptableObject<NotificatioData>(_data.BasePath + name);
    }
}
