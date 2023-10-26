using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityListener
{
    ON_MOVE_CLIENT, ON_VALIDATE_MOVEMENT, ON_SYNCHRONICE_POSITION, ON_INSPECT,ON_SET_POSITION,ON_SET_FACTOR, ON_NAVIGATE
}
public enum AbilityEvents
{
    MOVE_CLIENT, UPDATE_ROTATION, UPDATE_POSITION, UPDATE_LOCATION, INSPECT, STOP_INSPECT, SET_FACTOR,NAVIGATE
}

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField]
    protected Avatar character;
    [SerializeField]
    protected CharacterController characterController;
    [SerializeField]
    private BaseAnimationController _characterAnimationController;
    [SerializeField]
    private BaseOccupationController _characterOccupationController;


    protected bool GetIsClient()
    {
        return GetAdapter<NetworkAvatarAdapter>().IsPlayable;
    }


    private void Start()
    {
        OnStart();
    }
    protected virtual void OnStart()
    {

    } 
    private void FixedUpdate()
    {
        OnFixedLoop();
    }
    private void Update()
    {
        OnUpdate();
    }

    private void OnDestroy()
    {
        Destroy();
    }
    protected virtual void Destroy() { }
    protected abstract void OnUpdate();
    protected abstract void OnFixedLoop();


    public virtual void Init(AbilityData data) {
        _characterOccupationController = GetComponent<BaseOccupationController>();
        character = GetComponent<Avatar>();
        character.Collision += OnCollision;
        characterController = GetComponent<CharacterController>();
        _characterAnimationController = GetComponent<BaseAnimationController>();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    private void OnCollision(CollisionData collisionData)
    {
        if (collisionData.type.Equals(CollisionType.COLLISION_ENTER.ToString()))
        {
            CollisionEnter(collisionData);
        }
        if (collisionData.type.Equals(CollisionType.COLLISION_EXIT.ToString()))
        {
            CollisionExit(collisionData);
        }

    }

    protected T characterAnimationController<T>() where T: BaseAnimationController
    {
        return _characterAnimationController as T;
    }
    protected T characterOccupationController<T>() where T: BaseOccupationController
    {
        return _characterOccupationController as T;
    }


    protected abstract void CollisionEnter(CollisionData collisionData);
    protected abstract void CollisionExit(CollisionData collisionData);

    protected T GetAdapter<T>() where T : BaseAvatarAdapter
    {
        return GetComponent<T>();
    }


}
