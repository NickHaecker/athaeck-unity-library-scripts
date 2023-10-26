using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface InputSubscriber 
{
    public KeyCode KeyCode { get;  }
    public void TakeInput();
}
