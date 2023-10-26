using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClipType
{
    WALK,RUN,WALK_RF,WALK_LF
}
[RequireComponent(typeof(UnityEngine.AudioSource))]
public class BaseAudioSource : MonoBehaviour
{
    public UnityEngine.AudioSource Source;
    public ClipType Type;

    void Start()
    {
        Source = GetComponent<AudioSource>();        
    }

}
