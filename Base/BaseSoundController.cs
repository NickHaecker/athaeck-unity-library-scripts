using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseSoundController : MonoBehaviour, PassBaseSettingsData
{
    [SerializeField]
    protected List<BaseAudioSource> sources = new List<BaseAudioSource>();
    public void OnTakeSettingsData(BaseSettingsData baseSettings)
    {
        Init(baseSettings);
    }
    private void Start()
    {
        BaseGameController.Instance.TakeBaseSettingsReceiver(this);

        OnStart();
    }
    private void OnDestroy()
    {
        Destroy();
        BaseGameController.Instance.RemoveBaseSettingsReceiver(this);
    }
    protected abstract void Destroy();
    protected abstract void OnStart();
    protected abstract void Init(BaseSettingsData baseSettingsData);

    protected void Play(BaseAudioSource source)
    {
        source.Source.Play(0);
    }
    protected void Stop(BaseAudioSource source)
    {
        source.Source.Stop();
    }
    protected abstract BaseAudioSource FilterSource(ClipType clipType);
}
