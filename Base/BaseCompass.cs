using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCompass : MonoBehaviour
{
    [SerializeField]
    protected RawImage compasUI;
    [SerializeField]
    protected Transform playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakePointofInterests(List<BasePointOfInterest> basePointOfInterests)
    {
        foreach(BasePointOfInterest point in basePointOfInterests)
        {
            TakePointofInterest(point);
        }
    }
    protected void TakePointofInterest(BasePointOfInterest basePointOfInterest)
    {

    }
}
