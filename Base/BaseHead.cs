using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHead : MonoBehaviour,TakeCamera
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private CinemachineFreeLook _freeLook;

    private void FixedUpdate()
    {
        OnFixedUpdate();

    }

    protected virtual void OnFixedUpdate()
    {
        if (_camera == null)
        {
            return;
        }

        if (_freeLook == null)
        {
            return;
        }

        if (!_freeLook.gameObject.activeInHierarchy)
        {
            gameObject.transform.rotation = Quaternion.identity;

            return;
        }

        Vector3 lookDirection = _camera.transform.position - transform.position;

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    public void TakeCamera(Camera camera, CinemachineFreeLook freeLook)
    {
        _camera = camera;
        _freeLook = freeLook;
    }
}
