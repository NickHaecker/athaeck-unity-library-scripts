using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ReceivedEvent
{
    public string eventName;
    public object data;

    public static ReceivedEvent FromJson(string json)
    {
        ReceivedEvent evt = JsonConvert.DeserializeObject<ReceivedEvent>(json);
        return evt;
    }
    public Dictionary<string, object> GetBody()
    {
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
    }
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}
