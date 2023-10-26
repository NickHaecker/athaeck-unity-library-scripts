using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseSceneController : MonoBehaviour
{
    public Action<BaseSceneController> BeforeSceneStart;
    protected Action<BaseSceneController> SceneStart;
    public Action<BaseSceneController> AfterSceneStart;

    public Action<BaseSceneController> BeforeSceneClose;
    public Action<BaseSceneController> SceneClose;
    public Action<BaseSceneController> AfterSceneClose;

    private void Start()
    {
        foreach (BeforeSceneStart beforeSceneStart in GetComponentsInChildren<BeforeSceneStart>(true))
        {
            BeforeSceneStart += beforeSceneStart.OnBeforeSceneStart;
        }
        foreach (SceneStart sceneStart in GetComponentsInChildren<SceneStart>(true))
        {
            SceneStart += sceneStart.OnSceneStart;
        }
        foreach (AfterSceneStart afterSceneStart in GetComponentsInChildren<AfterSceneStart>(true))
        {
            AfterSceneStart += afterSceneStart.OnAfterSceneStart;
        }
        foreach (BeforeSceneClose beforeSceneClose in GetComponentsInChildren<BeforeSceneClose>(true))
        {
            BeforeSceneClose += beforeSceneClose.OnBeforeSceneClose;
        }
        foreach (SceneClose sceneClose in GetComponentsInChildren<SceneClose>(true))
        {
            SceneClose += sceneClose.OnSceneClose;
        }
        foreach (AfterSceneClose afterSceneClose in GetComponentsInChildren<AfterSceneClose>(true))
        {
            AfterSceneClose += afterSceneClose.OnAfterSceneClose;
        }

        OnStart();
    }
    public virtual void StartHook()
    {
        if(TryGetComponent<BaseStartDelay>(out BaseStartDelay baseStartDelay))
        {
            baseStartDelay.TakeDelayCallback(InvokeStart);
        }
        else
        {
            InvokeStart();
        }
    }
    public virtual void EndHook()
    {
        if(TryGetComponent<BaseEndDelay>(out BaseEndDelay baseEndDelay))
        {
            baseEndDelay.TakeDelayCallback(InvokeEnd);
        }
        else
        {
            InvokeEnd();
        }
    }
    private void InvokeEnd()
    {
        SceneClose?.Invoke(this);
        AfterSceneClose?.Invoke(this);
    }
    private void InvokeStart()
    {
        SceneStart?.Invoke(this);
    }
    protected abstract void OnStart();

    public T[] GetComponentsInChildren<T>(Component component) where T : Component
    {
        return this.gameObject.GetComponentsInChildren<T>(true);
    }
    public T GetComponentInChildren<T>(Component component) where T : Component
    {
        return this.gameObject.GetComponentInChildren<T>(true);
    }
    public abstract void OnEnd();
}

