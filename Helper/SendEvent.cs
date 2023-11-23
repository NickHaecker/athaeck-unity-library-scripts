using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent
{
    public string eventName;
    public Dictionary<string, object> data;

    public string JsonString
    {
        get
        {
            return JsonConvert.SerializeObject(this); ;
        }
    }

    public SendEvent(string name)
    {
        eventName = name;
        data = new Dictionary<string, object>();
    }

    public void AddData(string key, object value)
    {
        data.Add(key, value);
    }
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}
