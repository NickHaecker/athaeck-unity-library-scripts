using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseAvatar
{
    public string GetID();
    public BaseAvatarAdapter GetAvatarAdapter();
}
