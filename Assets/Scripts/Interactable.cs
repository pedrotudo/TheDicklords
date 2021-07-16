using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public TriggerActions Enter;
    public TriggerActions Exit;

    public bool Repeat = false;
    bool _repeatEnter = true;
    bool _repeatExit = true;

    public GameObject CollObject;

    private void OnEnable()
    {
        Enter.Initialize(this);
        Exit.Initialize(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        CollObject = other.gameObject;
        if (Enter != null && _repeatEnter == true)
        {
            Enter.ApplyAction();
            _repeatEnter = Repeat;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (Exit != null && _repeatExit == true)
        {
            Exit.ApplyAction();
            _repeatExit = Repeat;
        }
        CollObject = null;
    }

}
