using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public abstract class AbilityData : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString();
    public abstract void UseAbility(Avatar character);
    //public abstract void SynchronizeAbility(Character character);
}
