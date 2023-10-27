using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisionListener(CollisionData collisionData);

public interface BaseAvatar
{
    public string GetID();
    public BaseAvatarAdapter GetAvatarAdapter();
    public void AddCollisionListener(CollisionListener listener);
}
