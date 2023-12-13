using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameController : MonoBehaviour
{
    private static BaseGameController _instance = null;
    public static BaseGameController Instance { get { return _instance; } }

    protected BaseSceneController _baseSceneController;
    [field:SerializeField]
    public BaseUiController UiController { private set; get; }
    [field: SerializeField]
    protected BaseSettingsData settingsData;
    [field: SerializeField]
    private string _saveUrl = "/settings.data";

    public Action InitGame;
    public Action StartGame;
    public Action PauseGame;
    public Action EndGame;
    public Action ResumeGame;
    public Action SaveGame;
    public Action LoadGame;

    protected Action<BaseSettingsData> TakeSettingsData;

    private void Awake()
    {
        _instance = this;

        OnAwake();

        UiController = this.GetComponent<BaseUiController>();

        LoadGame += OnLoadGame;
        SaveGame += OnSaveGame;

        InitGame += OnInitGame;
        StartGame += OnStartGame;
        PauseGame += OnPauseGame;
        ResumeGame += OnResumeGame;
        EndGame += OnEndGame;

        InitGame?.Invoke();
    }
    protected virtual void OnAwake() { }
    protected abstract void OnStartGame();
    protected abstract void OnPauseGame();
    protected abstract void OnResumeGame();
    protected abstract void OnInitGame();
    public abstract void TakeSceneController(BaseSceneController baseSceneController);
    public abstract void EndSceneController(BaseSceneController baseSceneController);
    public abstract void SwitchScene(BaseSceneData sceneData);
    protected abstract void OnEndGame();

    public abstract T GetGameController<T>() where T : BaseGameController;

    public void TakeBaseSettingsReceiver(PassBaseSettingsData passBaseSettingsData)
    {
        TakeSettingsData += passBaseSettingsData.OnTakeSettingsData;

        passBaseSettingsData.OnTakeSettingsData(settingsData);
    }
    public void RemoveBaseSettingsReceiver(PassBaseSettingsData passBaseSettingsData)
    {
        TakeSettingsData -= passBaseSettingsData.OnTakeSettingsData;
    }
    private void OnLoadGame()
    {
        //try
        //{
        //_settingsData = StateManager.LoadDataForSave<BaseSettingsData>(_saveUrl);
        //if (_settingsData == null)
        //{
        //_settingsData = new BaseSettingsData();
        //        OnSaveGame();
        //    }
        //}
        //catch (Exception e)
        //{
        //    _settingsData = new BaseSettingsData();
        //    OnSaveGame();
        //}
        //TakeSettingsData?.Invoke(_settingsData);
    }
    private void OnSaveGame()
    {
        //StateManager.SaveDataForSave<BaseSettingsData>(_saveUrl, _settingsData);
    }
}
