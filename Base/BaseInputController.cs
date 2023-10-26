using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class BaseInputController : MonoBehaviour
{
    protected List<InputSubscriber> subscriptions = new List<InputSubscriber>();

    private void Start()
    {
        Lock();

        BaseGameController.Instance.PauseGame += OnPauseGame;
        BaseGameController.Instance.ResumeGame += OnResumeGame;
    }

    private void OnDestroy()
    {
        BaseGameController.Instance.PauseGame -= OnPauseGame;
        BaseGameController.Instance.ResumeGame -= OnResumeGame;
    }

    private void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnLock()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();

        if (subscriptions.Count == 0)
        {
            return;
        }

        ValidateSubscriptions();
    }

    private void OnPauseGame()
    {
        UnLock();
    }
    private void OnResumeGame()
    {
        Lock();
    }

    protected virtual void ValidateSubscriptions()
    {
        foreach (InputSubscriber subscriber in subscriptions.ToArray())
        {
            if (Input.GetKey(subscriber.KeyCode))
            {
                subscriber.TakeInput();
            }
        }
    }
    protected abstract void OnFixedUpdate();

    public virtual void SubscribeInput(InputSubscriber subscriber)
    {
        subscriptions.Add(subscriber);
    }
    public virtual void UnsubscribeInput(InputSubscriber subscriber)
    {
        subscriptions.Remove(subscriber);
    }
}
