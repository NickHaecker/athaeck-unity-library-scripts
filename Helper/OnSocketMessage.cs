using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public interface OnSocketMessage
{
    public void OnMessage(object sender, MessageEventArgs e);
}
