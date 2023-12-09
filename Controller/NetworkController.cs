using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class NetworkController : BaseNetworkController
{
    [SerializeField]
    private Queue<ReceivedEvent> _receivedEvents = new Queue<ReceivedEvent>();
    public override void Connect()
    {
        AfterWebSocketConnected += OnConnection;
        BeforeWebsocketConnected?.Invoke(this);
        socket = new WebSocket(adress);

        socket.Connect();

        socket.OnOpen += OnOpen;

        socket.OnMessage += OnMessage;
        socket.OnError += OnError;
        socket.OnClose += OnClose;

        AfterWebSocketConnected?.Invoke(socket);
    }

    public override void Disconnect()
    {
        BeforeWebSocketDisconnected += OnDisconnection;
        BeforeWebSocketDisconnected?.Invoke(socket);
        socket.Close();
        socket.OnOpen -= OnOpen;
        socket.OnMessage -= OnMessage;
        socket.OnError -= OnError;
        socket.OnClose -= OnClose;
        AfterWebSocketDisconnected?.Invoke(this);
    }
    public override void ConnectScene()
    {
        if(socket != null && socket.IsAlive)
        {
            BeforeWebsocketConnected?.Invoke(this);
            AfterWebSocketConnected?.Invoke(socket);
        }
    }
    public override void DisconnectScene()
    {
        if( socket != null && socket.IsAlive)
        {
            BeforeWebSocketDisconnected?.Invoke(socket);
            AfterWebSocketDisconnected?.Invoke(this);
        }
    }

    protected override void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log(e.Reason);
    }

    protected override void OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(e.Exception);
    }

    protected override void OnMessage(object sender, MessageEventArgs e)
    {
        ReceivedEvent response = ReceivedEvent.FromJson(e.Data);
        _receivedEvents.Enqueue(response);
    }

    private void FixedUpdate()
    {
        if (_receivedEvents.Count > 0)
        {
            for(int i = 0; i < _receivedEvents.Count; i++)
            {
                TakeEvent?.Invoke(_receivedEvents.Dequeue());
            }
        }
    }

    protected override void OnOpen(object sender, EventArgs e)
    {
        Debug.Log(e);
    }
    public WebSocket GetSocket()
    {
        return socket;
    }
}
