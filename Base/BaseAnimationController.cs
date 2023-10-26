using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimationController : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetFloat(string parameter, float value)
    {
        animator.SetFloat(parameter, value);
    }
    public float GetFloat(string parameter)
    {
        return animator.GetFloat(parameter);
    }
    public void SetBool(string parameter, bool state)
    {
        animator.SetBool(parameter, state);
    }
    public bool GetBool(string parameter)
    {
        return animator.GetBool(parameter);
    }
    public void SetTrigger(string type, bool state)
    {
        if (state)
        {
            animator.SetTrigger(type);
        }
        else
        {
            animator.ResetTrigger(type);
        }
    }
    protected T GetAdapter<T>() where T : BaseAvatarAdapter
    {
        return GetComponent<T>();
    }
}
