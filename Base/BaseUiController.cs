using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum UI_STATE
{
    OPEN, CLOSE
}

public class BaseUiController : MonoBehaviour
{
    protected Action<BaseUi> OpenUi;
    protected Action<BaseUi> CloseUi;
    private Action<BaseUi, UI_STATE> UpdateUi;

    [SerializeField]
    protected List<BaseUi> availableUis = new List<BaseUi>();
    [field:SerializeField]
    protected List<BaseUi> openUis
    {
        get
        {
            return availableUis.FindAll(i => i.IsUiOpen(out UiData d) == true);
        }
        set { 
        }
    }
    [SerializeField]
    private BaseUi _defaultUi;

    public void TakeBaseUi(BaseUi baseUi)
    {
        OpenUi += baseUi.OnOpenUi;
        CloseUi += baseUi.OnCloseUi;

        availableUis.Add(baseUi);

        HandleCloseUI(baseUi);
    }
    public void RemoveBaseUi(BaseUi baseUi)
    {
        OpenUi -= baseUi.OnOpenUi;
        CloseUi -= baseUi.OnCloseUi;

        availableUis.Remove(baseUi);

        HandleCloseUI(baseUi);
    }
    public void OpenDefaultUi(BaseUi defaultUi)
    {
        _defaultUi = defaultUi;

        foreach (BaseUi ui in availableUis)
        {
            CloseUi?.Invoke(ui);
        }

        OpenUi?.Invoke(_defaultUi);
    }

    private void Start()
    {
        UpdateUi += ValidateOverlay;
        UpdateUi += OnUpdateUi;
    }
    protected virtual void ValidateOverlay(BaseUi baseUi, UI_STATE state)
    {
        if (state.Equals(UI_STATE.OPEN) && baseUi.Data.UiType.Equals(UIType.OVERLAY))
        {
            if(_defaultUi == null)
            {
                return;
            }
            HandleCloseUI(_defaultUi);

            foreach (BaseUi ui in openUis)
            {
                if(ui.Data.UiType == UIType.OVERLAY)
                {
                    HandleCloseUI(ui);
                }
            }

            //TODO: cache extended screens an close or open after menu closes or opened
        }
        if (state.Equals(UI_STATE.CLOSE) && baseUi.Data.UiType.Equals(UIType.OVERLAY))
        {
            if (_defaultUi == null)
            {
                return;
            }

            HandleOpenUI(_defaultUi);
        }
    }
    protected virtual void OnUpdateUi(BaseUi baseUi, UI_STATE state)
    {
        if (state.Equals(UI_STATE.CLOSE))
        {
            CloseUi?.Invoke(baseUi);
        }
        if (state.Equals(UI_STATE.OPEN))
        {
            OpenUi?.Invoke(baseUi);
        }
    }

    public void HandleCloseUI(BaseUi ui)
    {
        UpdateUi?.Invoke(ui, UI_STATE.CLOSE);
    }
    public void HandleOpenUI(BaseUi ui)
    {
        UpdateUi?.Invoke(ui, UI_STATE.OPEN);
    }
    public void HandleCloseUI(UiData ui)
    {
        BaseUi baseUi = FindUiByData(ui);
        HandleCloseUI(baseUi);
    }
    public void HandleOpenUI(UiData ui)
    {
        BaseUi baseUi = FindUiByData(ui);
        HandleOpenUI(baseUi);
    }
    private BaseUi FindUiByData(UiData data)
    {
        return availableUis.Find(item => item.Data.ID == data.ID);
    }
    public bool IsUiOpen(BaseUi ui)
    {
        return openUis.Contains(ui);
    }
    public bool IsUiOpen(UiData ui)
    {
        return IsUiOpen(FindUiByData(ui));
    }
    
}
