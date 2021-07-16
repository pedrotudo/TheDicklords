using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerActionType
{
    NONE,
    DESTROY_MYSELF,
    DESTROY_COLL_OBJECT,
    CUSTOM_EVENT
}
public class TriggerActions : MonoBehaviour
{
    public TriggerActionType MyAction;

    [Space]
    
    public string EventName;
    public string EventAmount;

    Interactable _parent;

    public void Initialize(Interactable interactable)
    {
        _parent = interactable;
    }

    public void ApplyAction()
    {
        GameObject collObject = _parent.CollObject;
        switch (MyAction)
        {
            case TriggerActionType.NONE:
                break;
            case TriggerActionType.DESTROY_MYSELF:  
                Destroy(_parent.gameObject);
                break;
            case TriggerActionType.DESTROY_COLL_OBJECT:
                Destroy(collObject);
                break;
            case TriggerActionType.CUSTOM_EVENT:
                GameEvents.CustomEvent(EventName, EventAmount);
                break;

            default:
                break;
        }
    }
}
