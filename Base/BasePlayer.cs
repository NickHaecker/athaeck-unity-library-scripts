using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    protected static BasePlayer instance = null;
    public static BasePlayer Instance { get { return instance; } }
    [SerializeField]
    protected PlayerData playerData;
    [SerializeField]
    protected string saveUrl = "Playerdata.Data";


    public abstract void TakeBaseGameController(BaseGameController baseGameController);
    protected abstract void OnLoad();
    protected abstract void OnSave();

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public abstract T GetPlayer<T>() where T:BasePlayer;

}

