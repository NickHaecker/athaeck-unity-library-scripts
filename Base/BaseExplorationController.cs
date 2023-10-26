using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseExplorationController : MonoBehaviour, BeforeSceneStart, SceneStart, PassExplorationComponent,PassBasePointOfInterest,RemoveBasePointOfInterest
{
    private static BaseExplorationController _instance = null;
    public static BaseExplorationController Instance { get { return _instance; } }

    public Action<BasePointOfInterest> DiscoverPointOfInterest;
    public Action<BasePointOfInterest> InspectPointOfInterest;

    [SerializeField]
    protected List<BasePointOfInterest> pointsOfInterests = new List<BasePointOfInterest>();

    //[SerializeField]
    //protected BaseCompass compas;

    public void OnBeforeSceneStart(BaseSceneController baseSceneController)
    {

    }





    void Start()
    {
        _instance = this;
    }

    void Update()
    {

    }

    public void TakeBasePointofInterest(BasePointOfInterest basePointOfInterest)
    {
        pointsOfInterests.Add(basePointOfInterest);
    }

    public void OnSceneStart(BaseSceneController baseSceneController)
    {

    }

    public void TakeExplorationComponent(ExplorationComponent explorationComponent)
    {

        explorationComponent.PassExplorationActions(this);
    }

    public void RemoveExplorationComponent(ExplorationComponent explorationComponent)
    {
        explorationComponent.RemoveExplorationActions(this);
    }

    public void RemoveBasePointofInterest(BasePointOfInterest basePointOfInterest)
    {
       pointsOfInterests.Remove(basePointOfInterest);
    }
}
