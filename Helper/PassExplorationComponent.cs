using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PassExplorationComponent
{
    public void TakeExplorationComponent(ExplorationComponent explorationComponent);
    public void RemoveExplorationComponent(ExplorationComponent explorationComponent);
}
