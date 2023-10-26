using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : DataForSave
{
    //private string _path = "/playerData.data";

    public List<string> Abilitys = new List<string> { "1135008e-816e-4a20-bcd6-27e9c0656a14", "892d4dc4-e05f-4acf-89ec-61175fb4fb68" };

    //public override void Load<T>()
    //{
    //    PlayerData playerData = StateManager.LoadDataForSave<PlayerData>(GetPath());
    //    if (playerData == null)
    //    {
    //        playerData = new PlayerData { Abilitys = new List<string> { "1135008e-816e-4a20-bcd6-27e9c0656a14" } };
    //    }
    //    Abilitys = playerData.Abilitys;
    //}
    //protected override string GetPath()
    //{
    //    return _path;
    //}
}
