using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
    public override void Awake()
    {
        Debug.Log("Awake Game");
        MainMenuPanel.OnStartPressed += LoadLevel;
        InGameHudPanel.OnEndSessionPressed += LoadInitialScene;

    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Game");
        MainMenuPanel.OnStartPressed -= LoadLevel;
        InGameHudPanel.OnEndSessionPressed -= LoadInitialScene;
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

    private void LoadInitialScene()
    {
        SceneManager.LoadScene("InitialScene");
    }
}
