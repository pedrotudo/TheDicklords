using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instace;
    private void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
        }
        Debug.Log("Awake LevelHandler");
    }
}
