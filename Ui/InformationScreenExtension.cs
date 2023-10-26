using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationScreenExtension : BaseUi
{
    [SerializeField]
    private NotificatioData _notificationData;
    [SerializeField]
    private TMP_Text _notification;
    [SerializeField]
    private GameObject _background;

    protected override void AfterUiClosed()
    {
        _notification.text = string.Empty;
    }

    protected override void AfterUiOpened()
    {

    }

    protected override void BeforeUiClosed()
    {

    }

    protected override void BeforeUiOpened()
    {
        _notification.text = _notificationData.Notification;
    }
    protected override void OnStart()
    {
        base.OnStart();

        NotificationController.Instance.Info += OnInfo;
    }

    private void OnInfo(NotificatioData notificationData)
    {
        _notificationData = notificationData;
    }

    protected override void Destroy()
    {
        NotificationController.Instance.Info -= OnInfo;

        base.Destroy();
    }
    public override void ExtendableBehaviour(bool state)
    {
        _background.SetActive(state);
    }
}
