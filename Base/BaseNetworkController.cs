using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Net;
using UnityEngine;
using System;
using System.Threading;

public abstract class BaseNetworkController : MonoBehaviour
{
    protected WebSocket socket;
    [SerializeField]
    protected string adress = "ws://localhost:8080";
    [SerializeField]
    private Thread _socketThread;
    [SerializeField]
    protected bool connected = false;
    [SerializeField]
    private int _delay = 5;

    public Action<BaseNetworkController> BeforeWebsocketConnected;
    public Action<WebSocket> AfterWebSocketConnected;
    public Action<WebSocket> BeforeWebSocketDisconnected;
    public Action<BaseNetworkController> AfterWebSocketDisconnected;
    public Action<ReceivedEvent> TakeEvent;

    public abstract void Connect();
    public abstract void ConnectScene();
    public abstract void Disconnect();
    public abstract void DisconnectScene();
    protected abstract void OnMessage(object sender, MessageEventArgs e);
    protected abstract void OnClose(object sender, CloseEventArgs e);
    protected abstract void OnOpen(object sender, EventArgs e);
    protected abstract void OnError(object sender, ErrorEventArgs e);

    protected void OnConnection(WebSocket socket)
    {
        connected = true;
        _socketThread = new Thread(RunSocketThread);
        _socketThread.Start(socket);
    }
    protected void OnDisconnection(WebSocket socket)
    {
        connected = false;
    }
    private void RunSocketThread(object obj)
    {
        WebSocket webSocket = (WebSocket)obj;
        while (connected)
        {
            if (webSocket.IsAlive)
            {
                Thread.Sleep(_delay);
            }
            else
            {
                webSocket.Connect();
            }
        }
        webSocket.Close();
    }
}
