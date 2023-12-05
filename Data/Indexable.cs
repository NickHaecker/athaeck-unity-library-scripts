using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScriptableObjectData
{ }

public abstract class Indexable : ScriptableObject
{
    public abstract void AddEventData(SendEvent sendEvent);
    public abstract T GetData<T>() where T : ScriptableObjectData;
}
