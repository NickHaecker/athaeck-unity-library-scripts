using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerController : MonoBehaviour
{
    public Action<BaseAvatar> BeforeCharacterCreated;
    public Action<BaseAvatar> AfterCharacterCreated;
}
