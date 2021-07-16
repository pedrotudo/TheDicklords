using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public GameObject TriggerEnterAction;
    public GameObject TriggerExitAction;

    public GameObject CollObject;

    public void OnTriggerEnter(Collider other)
    {
        CollObject = other.gameObject;
        if (TriggerEnterAction != null)
            TriggerEnterAction.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        CollObject = null;
        if (TriggerExitAction != null)
            TriggerExitAction.SetActive(true);
    }

}
