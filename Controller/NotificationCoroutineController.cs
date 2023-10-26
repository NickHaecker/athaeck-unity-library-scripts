using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NotificationCoroutineController : MonoBehaviour
{
    [SerializeField]
    private bool _isGamePaused = false;
    [SerializeField]
    private Coroutine _coroutine;
    [SerializeField]
    private NotificatioData _notificatioData;
    [SerializeField]
    private UiData _uiData;
    [SerializeField]
    private CoroutineEndCallback _coroutineEndCallback;


    public void Init(NotificatioData notificatioData, UiData uiData, CoroutineEndCallback coroutineEndCallback, bool gamePaused)
    {
        _uiData = uiData;
        _notificatioData = notificatioData;
        _coroutineEndCallback = coroutineEndCallback;
        _isGamePaused = gamePaused;
    }

    public void StartCoroutine()
    {
        _coroutine = StartCoroutine(DisableNotifiction());
    }

    IEnumerator DisableNotifiction()
    {
        yield return new WaitForSeconds(10);

        if (_isGamePaused)
        {
            StartCoroutine(DisableNotifiction());
        }
        else
        {
            _coroutineEndCallback(this);
            End();
        }
    }

    private void End()
    {
        Destroy(this);
    }

    public void OnPauseGame()
    {
        _isGamePaused = true;
    }
    public void OnResumeGame()
    {
        _isGamePaused = false;
    }
    public NotificatioData GetNotificatioData() { return _notificatioData; }
    public UiData GetUiData() { return _uiData; }
}
public delegate void CoroutineEndCallback(NotificationCoroutineController notificationCoroutineController);
