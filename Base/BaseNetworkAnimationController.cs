using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationListener
{
    SET_FLOAT, SET_BOOL, SET_TRIGGER, RESET_TRIGGER
}
public enum AnimationEvents
{
    SYNCHRONIZE_ANIMATOR
}

public delegate void AnimationListenerCallback(ReceivedEvent received);
public static class Listener
{
    public static void TakeCallback(AnimationListener type, ReceivedEvent receivedEvent, AnimationListenerCallback callback)
    {
        if (type.ToString() == receivedEvent.eventName)
        {
            callback(receivedEvent);
        }
    }
}
public class BaseNetworkAnimationController : BaseAnimationController, TakeEvent
{
    public void OnTakeEvent(ReceivedEvent receivedEvent)
    {
        if (!Enum.IsDefined(typeof(AnimationListener), receivedEvent.eventName))
        {
            return;
        }

        Listener.TakeCallback(AnimationListener.SET_FLOAT, receivedEvent, NetworkSetFloat);
        Listener.TakeCallback(AnimationListener.SET_BOOL, receivedEvent, NetworkSetBool);
        Listener.TakeCallback(AnimationListener.SET_TRIGGER, receivedEvent, NetworkSetTrigger);
        Listener.TakeCallback(AnimationListener.RESET_TRIGGER, receivedEvent, NetworkResetTrigger);
    }
    private void NetworkSetFloat(ReceivedEvent receivedEvent)
    {
        if (!IsAnimatorBodyAvailable(receivedEvent))
        {
            return;
        }
        SyncAnimationSetFloat setFloat = JsonConvert.DeserializeObject<SyncAnimationSetFloat>(GetBody(receivedEvent).ToString());

        if (GetAdapter<NetworkAvatarAdapter>().ClientData.ID != setFloat.Client)
        {
            return;
        }
        SetFloat(setFloat.Type, setFloat.Value);
    }
    private void NetworkSetTrigger(ReceivedEvent receivedEvent)
    {
        if (!IsAnimatorBodyAvailable(receivedEvent))
        {
            return;
        }
        SyncAnimationSetTrigger setTrigger = JsonConvert.DeserializeObject<SyncAnimationSetTrigger>(GetBody(receivedEvent).ToString());

        if (GetAdapter<NetworkAvatarAdapter>().ClientData.ID != setTrigger.Client)
        {
            return;
        }
        SetTrigger(setTrigger.Type, setTrigger.Value);
    }
    private void NetworkResetTrigger(ReceivedEvent receivedEvent)
    {
        if (!IsAnimatorBodyAvailable(receivedEvent))
        {
            return;
        }
        SyncAnimationResetTrigger resetTrigger = JsonConvert.DeserializeObject<SyncAnimationResetTrigger>(GetBody(receivedEvent).ToString());

        if (GetAdapter<NetworkAvatarAdapter>().ClientData.ID != resetTrigger.Client)
        {
            return;
        }
        SetTrigger(resetTrigger.Type, resetTrigger.Value);
    }
    private void NetworkSetBool(ReceivedEvent receivedEvent)
    {
        if (!IsAnimatorBodyAvailable(receivedEvent))
        {
            return;
        }
        SyncAnimationSetBool setBool = JsonConvert.DeserializeObject<SyncAnimationSetBool>(GetBody(receivedEvent).ToString());

        if (GetAdapter<NetworkAvatarAdapter>().ClientData.ID != setBool.Client)
        {
            return;
        }
        SetBool(setBool.Type, setBool.Value);
    }
    private bool IsAnimatorBodyAvailable(ReceivedEvent receivedEvent)
    {
        return receivedEvent.GetBody().ContainsKey("Animator");
    }
    private object GetBody(ReceivedEvent receivedEvent)
    {
        return receivedEvent.GetBody()["Animator"];
    }
}
