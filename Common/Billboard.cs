using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour, PassCameraController
{
    [SerializeField]
    private GameObject _cam;

    public void TakeCameraController(BaseCameraController baseCameraController)
    {
        _cam = baseCameraController.GetCamera().gameObject;
    }

    private void FixedUpdate()
    {
        if (_cam == null)
        {
            return;
        }
        transform.LookAt(transform.position + _cam.transform.forward);
    }
}
