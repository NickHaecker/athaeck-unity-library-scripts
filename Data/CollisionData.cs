using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionData
{
    public string type;
    public GameObject origin;
    public string originType;

    public CollisionData(string type, GameObject origin, string originType)
    {
        this.type = type;
        this.origin = origin;
        this.originType = originType;
    }
}
public enum CollisionType
{
    COLLISION_ENTER, COLLISION_EXIT, NULL
}
public enum BlockState
{
    CLIMB, INTERACT, HOLD, GROUNDED, DIALOGUE, PICK, DROP, JUMP, CHARACTER_INTERACTION, PAUSE, INSPECT, WALK, OPEN_MENUE, NAVIGATE
}
public enum InformationType
{
    CONTROLLER_COLLIDER
}