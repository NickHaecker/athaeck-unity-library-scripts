using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementAbility
{
    public void TakeMovement(Vector3 direction,MovementType movementType);
    public void TakeSneak();
    public void TakeSprint();
}
