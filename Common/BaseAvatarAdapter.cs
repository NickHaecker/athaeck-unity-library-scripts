using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAvatarAdapter : MonoBehaviour
{
    [SerializeField]
    public GameObject LookAt;
    [SerializeField]
    public GameObject EyeHeight;
    [SerializeField]
    public CinemachineVirtualCamera FirstPerson;
}
