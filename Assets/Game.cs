using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instace;

    private void Awake()
    {
        Debug.Log("Awake Game");
        if (Instace == null)
        {
            Instace = this;
        }

        Player.OnPlayerIsDead += OnPlayerIsDeadBehaviour;

    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Game");

        Player.OnPlayerIsDead -= OnPlayerIsDeadBehaviour;
    }

    private void OnPlayerIsDeadBehaviour()
    {
        Debug.Log("Restart");
        GameEnd();
    }

    private void GameStart()
    {
        Debug.Log("Start game");
    }

    private void GameEnd()
    {
        Debug.Log("End game");
    }
}
