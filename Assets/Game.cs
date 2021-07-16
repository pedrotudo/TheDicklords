using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instace;

    private void Awake()
    {
        Debug.Log("Awake Game");
        Instace = this;
        Player.OnPlayerIsDead += OnPlayerIsDeadBehaviour;
        MainMenuPanel.OnStartPressed += LoadLevel;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Game");
        Player.OnPlayerIsDead -= OnPlayerIsDeadBehaviour;
        MainMenuPanel.OnStartPressed -= LoadLevel;
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

    private void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
