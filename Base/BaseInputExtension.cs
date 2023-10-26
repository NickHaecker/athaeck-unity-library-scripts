using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInputExtension : MonoBehaviour, InputSubscriber, BeforeSceneStart, BeforeSceneClose
{
    KeyCode InputSubscriber.KeyCode { get => key; }
    [SerializeField]
    protected KeyCode key;

    [SerializeField]
    protected bool clicked = false;

    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    protected abstract void OnUpdate();
    protected abstract void OnFixedUpdate();
    protected abstract void OnStart();

    protected void SubscribeComponent(BaseInputController baseInputController)
    {
        baseInputController.SubscribeInput(this);
    }

    protected void UnsubscribeComponent(BaseInputController baseInputController)
    {
        baseInputController.UnsubscribeInput(this);
    }

    public void TakeInput()
    {
        OnTakeInput();
        clicked = true;
        StartCoroutine(Click());
    }
    protected abstract void OnTakeInput();

    IEnumerator Click()
    {
        yield return new WaitForSeconds(1f);
        clicked = false;
    }

    public void OnBeforeSceneStart(BaseSceneController baseSceneController)
    {
        InputController inputController = baseSceneController.GetComponentInChildren<InputController>();
        SubscribeComponent(inputController);
    }

    public void OnBeforeSceneClose(BaseSceneController baseSceneController)
    {
        InputController inputController = baseSceneController.GetComponentInChildren<InputController>();
        UnsubscribeComponent(inputController);
    }
}
