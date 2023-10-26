using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameStateChanger : MonoBehaviour
{
    public void PauseGame()
    {
        BaseGameController.Instance.PauseGame?.Invoke();
    }
    public void ResumeGame()
    {
        BaseGameController.Instance.ResumeGame?.Invoke();
    }
}
