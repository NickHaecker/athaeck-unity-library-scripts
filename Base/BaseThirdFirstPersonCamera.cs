using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BaseThirdFirstPersonCamera : BaseSingleCameraController
{
    [SerializeField]
    protected bool fadeIn = false;
    [SerializeField]
    protected bool fadeOut = false;
    [SerializeField]
    protected CinemachineVirtualCamera firstPersonCamera;


    public Action BeforeFadeIn;
    public Action AfterFadeIn;
    public Action AfterFadeOut;
    public Action BeforeFadeOut;

    protected override void OnStart()
    {
        base.OnStart();
        BeforeFadeIn += OnBeforeFadeIn;
        BeforeFadeOut += OnBeforeFadeOut;
        AfterFadeIn += OnAfterFadeIn;
        AfterFadeOut += OnAfterFadeOut;

        BaseGameController.Instance.PauseGame += OnPauseGame;
        BaseGameController.Instance.ResumeGame += OnResumeGame;
    }


    private void Update()
    {
        if (fadeIn)
        {
            if (brain.IsBlending)
            {
                return;
            }
            fadeIn = false;
            AfterFadeIn?.Invoke();
        }
        if (fadeOut)
        {
            if (brain.IsBlending)
            {
                return;
            }
            fadeOut = false;
            AfterFadeOut?.Invoke();
        }
    }

    private void OnBeforeFadeIn()
    {
        fadeIn = true;
    }

    private void OnBeforeFadeOut()
    {
        sceneCamera.cullingMask = LayerMask.NameToLayer("Everything");
        fadeOut = true;
    }

    private void OnAfterFadeIn()
    {
        sceneCamera.cullingMask = ~(1 << 7);
    }

    private void OnAfterFadeOut()
    {

    }

    private void OnPauseGame()
    {
        OpenFirstPersonView();
    }
    private void OnResumeGame()
    {
        OpenThirdPersonView();
    }

    private void OnDestroy()
    {
        BaseGameController.Instance.PauseGame -= OnPauseGame;
        BaseGameController.Instance.ResumeGame -= OnResumeGame;
    }
    public void OpenFirstPersonView(CinemachineVirtualCamera virtualCamera = null)
    {
        CinemachineVirtualCamera firstPerson = virtualCamera ?? firstPersonCamera;

        baseCamera.gameObject.SetActive(false);
        firstPerson.gameObject.SetActive(true);

        BeforeFadeIn?.Invoke();
    }
    public void OpenThirdPersonView(CinemachineVirtualCamera virtualCamera = null)
    {
        CinemachineVirtualCamera firstPerson = virtualCamera ?? firstPersonCamera;

        firstPerson.gameObject.SetActive(false);
        baseCamera.gameObject.SetActive(true);

        BeforeFadeOut?.Invoke();
    }
}

