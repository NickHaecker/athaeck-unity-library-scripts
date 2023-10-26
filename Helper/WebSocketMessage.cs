using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public interface WebSocketMessage
{
    public void OnMessage(object sender, MessageEventArgs e);
}
