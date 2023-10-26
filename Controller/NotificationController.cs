using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NotificationController : MonoBehaviour
{
    private static NotificationController _instance = null;
    public static NotificationController Instance { get { return _instance; } }

    public Action<NotificatioData> Info;
    public Action<NotificatioData> Warning;
    public Action<NotificatioData> Error;

    [SerializeField]
    private UiData _informationsExtension;
    [SerializeField]
    private UiData _warningExtension;
    [SerializeField]
    private UiData _errorExtension;

    [SerializeField]
    private List<NotificationCoroutineController> _coroutines = new List<NotificationCoroutineController>();
    [SerializeField]
    private List<NotificatioData> _cachedNotifications = new List<NotificatioData>();
    [SerializeField]
    private bool _isGamePaused = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        BaseGameController.Instance.PauseGame += OnPauseCoroutines;
        BaseGameController.Instance.ResumeGame += OnResumeCoroutines;

        BaseGameController.Instance.UiController.HandleCloseUI(_informationsExtension);
        BaseGameController.Instance.UiController.HandleCloseUI(_warningExtension);
        BaseGameController.Instance.UiController.HandleCloseUI(_errorExtension);
    }

    private void OnPauseCoroutines()
    {
        _isGamePaused = true;
    }
    private void OnResumeCoroutines()
    {
        _isGamePaused = false;
    }

    private bool IsNotificationContaining(NotificatioData notificatioData)
    {
        bool hit = false;
        foreach (NotificationCoroutineController controller in _coroutines)
        {
            if (controller.GetNotificatioData().Type == notificatioData.Type)
            {
                hit = true;
            }
        }
        return hit;
    }

    public void SpawnNotification(NotificatioData notification, bool cached = false)
    {
        if (!cached)
        {
            if (IsNotificationContaining(notification))
            {
                _cachedNotifications.Add(notification);
                return;
            }
            
        }

        UiData ui;
        switch (notification.Type)
        {
            case NotificationType.WARNING:
                ui = _warningExtension;
                Warning?.Invoke(notification);
                break;
            case NotificationType.ERROR:
                ui = _errorExtension;
                Error?.Invoke(notification);
                break;
            default:
                ui = _informationsExtension;
                Info.Invoke(notification);
                break;
        }
        BaseGameController.Instance.UiController.HandleOpenUI(ui);

        NotificationCoroutineController notificationCoroutineController = gameObject.AddComponent<NotificationCoroutineController>();
        notificationCoroutineController.Init(notification, ui, RemoveCoroutine,_isGamePaused);

        BaseGameController.Instance.PauseGame += notificationCoroutineController.OnPauseGame;
        BaseGameController.Instance.ResumeGame += notificationCoroutineController.OnResumeGame;

        notificationCoroutineController.StartCoroutine();
        _coroutines.Add(notificationCoroutineController);
    }


    private void CloseUi(UiData ui)
    {
        BaseGameController.Instance.UiController.HandleCloseUI(ui);
    }

    private void RemoveCoroutine(NotificationCoroutineController notificationCoroutineController)
    {
        foreach(NotificationCoroutineController notificationCoroutine in _coroutines.ToArray())
        {
            if(notificationCoroutine.GetNotificatioData().Type == notificationCoroutineController.GetNotificatioData().Type)
            {
                _coroutines.Remove(notificationCoroutineController);
            }
        }

        BaseGameController.Instance.PauseGame -= notificationCoroutineController.OnPauseGame;
        BaseGameController.Instance.ResumeGame -= notificationCoroutineController.OnResumeGame;

        
        CloseUi(notificationCoroutineController.GetUiData());

        NotificatioData newNotification = GetCachedNotification(notificationCoroutineController.GetNotificatioData());

        if(newNotification == null)
        {
            return;
        }

        SpawnNotification(newNotification,true);
        _cachedNotifications.Remove(newNotification);
    }

    private NotificatioData GetCachedNotification(NotificatioData notificatioData)
    {
        NotificatioData next = _cachedNotifications.Find(i => i.Type == notificatioData.Type);
        return next;
    }

    private void OnDestroy()
    {
        BaseGameController.Instance.PauseGame -= OnPauseCoroutines;
        BaseGameController.Instance.ResumeGame -= OnResumeCoroutines;
    }
}
