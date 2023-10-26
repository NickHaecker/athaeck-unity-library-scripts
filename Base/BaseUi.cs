using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUi : MonoBehaviour
{
    [SerializeField]
    protected UiData data;
    [SerializeField]
    private GameObject _ui;

    void Start()
    {
        BaseGameController.Instance.UiController.TakeBaseUi(this);

        OnStart();
    }

    protected virtual void OnStart()
    {

    }


    public UiData Data
    {
        get { return data; }
    }

    private void OnDestroy()
    {
        BaseGameController.Instance.UiController.RemoveBaseUi(this);
        Destroy();
    }

    protected virtual void Destroy()
    {

    }

    public void OnOpenUi(BaseUi baseUi)
    {
        if (baseUi.Data.ID != data.ID)
        {
            return;
        }
        ValidateStateChange(true);
    }
    public void OnCloseUi(BaseUi baseUi)
    {
        if (baseUi.Data.ID != data.ID)
        {
            return;
        }
        ValidateStateChange(false);
    }

    private void ValidateStateChange(bool state)
    {
        if (state)
        {
            BeforeUiOpened();
        }
        else
        {
            BeforeUiClosed();
        }

        _ui.SetActive(state);

        if (state)
        {
            AfterUiOpened();
        }
        else
        {
            AfterUiClosed();
        }
    }
    public bool IsUiOpen(out UiData data)
    {
        data = this.data;
        return _ui.activeInHierarchy;
    }
    public virtual void ExtendableBehaviour(bool state) { }

    public GameObject GetUi() { return _ui; }

    protected abstract void BeforeUiOpened();
    protected abstract void AfterUiOpened();
    protected abstract void AfterUiClosed();
    protected abstract void BeforeUiClosed();
}
