using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WarningScreenExtension : BaseUi
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

        NotificationController.Instance.Warning += OnWarning;
    }

    private void OnWarning(NotificatioData notificationData)
    {
        _notificationData = notificationData;
    }

    protected override void Destroy()
    {
        NotificationController.Instance.Warning -= OnWarning;

        base.Destroy();
    }
    public override void ExtendableBehaviour(bool state)
    {
        _background.SetActive(state);
    }
}
