using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private GameObject _tooltip;

    void Start()
    {
        _tooltip.SetActive(false);
    }

    public void Show()
    {
        _tooltip.SetActive(true);
    }
    public void Close()
    {
        _tooltip.SetActive(false);
    }
}
