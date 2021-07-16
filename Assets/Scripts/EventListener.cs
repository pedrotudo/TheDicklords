using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnCustomEvent += CustomEvent;
    }
    private void OnDisable()
    {
        GameEvents.OnCustomEvent -= CustomEvent;
    }

    void CustomEvent(string name, string amount)
    {
        Debug.Log($"Event Name: {name} Amount: {amount}");
    }
}
