using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BaseWebsocketEventTypes 
{
    DISCONNECT_CLIENT, INSTANTIATE_CLIENT,INSTANTIATE_OTHER_CLIENTS,INSTANTIATE_NEW_CLIENT,CONNECT_PLAYER, DISCONNECT_PLAYER
}
public static class BaseWebsocketHelper
{
    public static bool CompareEvent(string eventName, BaseWebsocketEventTypes eventType)
    {
        return eventName == ConvertToString(eventType);
    }
    public static string ConvertToString(BaseWebsocketEventTypes baseWebsocketEventTypes)
    {
        return baseWebsocketEventTypes.ToString();
    }
}