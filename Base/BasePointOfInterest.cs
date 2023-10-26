using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BasePointOfInterest : MonoBehaviour, BeforeSceneStart, ExplorationComponent, AfterSceneClose
{
    [SerializeField]
    private Sprite _coverdSymbol;
    [SerializeField]
    private Sprite _discoverdSymbol;
    [SerializeField]
    private bool _isDiscoverd = false;
    [SerializeField]
    private string _title;
    [TextArea(3, 800)]
    [SerializeField]
    private string _description;
    [SerializeField]
    private string ID = "";

    public Sprite GetSymbol()
    {
        return _isDiscoverd ? _discoverdSymbol : _coverdSymbol;
    }

    private void OnDiscoverPointOfInterest(BasePointOfInterest pointOfInterest)
    {
        if (ID != pointOfInterest.GetID())
        {
            return;
        }
        if (_isDiscoverd)
        {
            return;
        }

        _isDiscoverd = true;
    }

    public void OnBeforeSceneStart(BaseSceneController baseSceneController)
    {
        ID = _title.Replace(" ", "");

        PassBasePointOfInterest passBasePointOfInterest = baseSceneController.GetComponentInChildren<PassBasePointOfInterest>();
        passBasePointOfInterest.TakeBasePointofInterest(this);

        PassExplorationComponent passBaseExplorationController = baseSceneController.GetComponentInChildren<PassExplorationComponent>();
        passBaseExplorationController.TakeExplorationComponent(this);

    }
    public string GetID()
    {
        return ID;
    }

    public void GetFacts(out string title, out string description,out Sprite discoveredSymbol,out bool isDiscovered)
    {
        title = _title;
        description = _description;
        discoveredSymbol = _discoverdSymbol;
        isDiscovered = _isDiscoverd;
    }

    public void PassExplorationActions(BaseExplorationController baseExplorationController)
    {
        baseExplorationController.DiscoverPointOfInterest += OnDiscoverPointOfInterest;
    }

    public void RemoveExplorationActions(BaseExplorationController baseExplorationController)
    {
        baseExplorationController.DiscoverPointOfInterest -= OnDiscoverPointOfInterest;
    }

    public void OnAfterSceneClose(BaseSceneController baseSceneController)
    {
        RemoveBasePointOfInterest removeBasePointOfInterest = baseSceneController.GetComponentInChildren<RemoveBasePointOfInterest>();
        removeBasePointOfInterest.RemoveBasePointofInterest(this);

        PassExplorationComponent passBaseExplorationController = baseSceneController.GetComponentInChildren<PassExplorationComponent>();
        passBaseExplorationController.RemoveExplorationComponent(this);
    }
}
