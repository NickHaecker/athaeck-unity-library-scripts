using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PassInspectionComponent
{
    public void TakeInspectionComponent(InspectionComponent inspectionComponent);
    public void RemoveInspectionCompoennt(InspectionComponent inspectionComponent);
}
