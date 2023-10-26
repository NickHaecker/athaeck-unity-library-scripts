using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EXPLORATION_ACTION
{
    DISCOVER,INSPECT
}
public interface ExplorationComponent
{
    public void PassExplorationActions(BaseExplorationController baseExplorationController);
    public void RemoveExplorationActions(BaseExplorationController baseExplorationController);
}




