using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void MovementEventCallback(Quaternion rotation, Vector3 direction);
public delegate void BeforeStartMovement();
public delegate void AfterStopMovement();
public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject _target = null;
    [SerializeField] 
    private AfterStopMovement _afterStopMovement = null;
    [SerializeField] 
    private MovementEventCallback _eventCallback = null;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(_target == null)
        {
            return;
        }

        if(Vector3.Distance(transform.position, _target.transform.position) >= 0.5)
        {
            Vector3 movementDirection = (_target.transform.position - transform.position).normalized;

            Quaternion targetRotation = Utils.RotateToTarget(_target, transform);

            if (_eventCallback != null)
            {
                _eventCallback(targetRotation, movementDirection);
            }
        }
        else
        {
            _target = null;

            _afterStopMovement();
        }

    }

    public void TakeTarget(GameObject target,BeforeStartMovement beforeStartMovement, AfterStopMovement afterStopMovement, MovementEventCallback eventCallback = null)
    {
        beforeStartMovement();

        _afterStopMovement= afterStopMovement;
        _eventCallback = eventCallback;
        _target = target;
    }

}
