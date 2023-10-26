using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiData", menuName = "Data/UiData")]
[Serializable]
public class UiData : ScriptableObject
{
    public string ID = "";
    public UIType UiType;
}
public enum UIType
{
    EXTEND, OVERLAY, DEFAULT, END, START
}
