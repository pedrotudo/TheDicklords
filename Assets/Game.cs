using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
    public static Action OnLoadScene;

    private int _level;
    public int Level => _level;

    private Player _playerReference;

    public int HP;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("Awake Game");
        EndGamePanel.OnSessionRestartPressed += TryAgain;
        EndGamePanel.OnEndSessionPressed += Quit;
        SceneManager.sceneLoaded += OnLoadSceneBehaviour;
        GameEvents.OnCustomEvent += CustomEventBehviour;
    }

    private void CustomEventBehviour(string eventName, string value)
    {
        if (!string.Equals(eventName, "win"))
        {
            return;
        }

        int level = int.Parse(value);

        LoadSceneByLevelNumber(level);
    }

    private void OnLoadSceneBehaviour(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.name == "InitialScene")
        {
            return;
        }

        // if level 1 is loaded reset the player
        if (scene.buildIndex == 1)
        {
            HP = 100;
        }
    }

    private void Start()
    {
        Debug.Log("Start game");
        LoadSceneByLevelNumber(1);
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Game");
        EndGamePanel.OnSessionRestartPressed -= TryAgain;
        EndGamePanel.OnEndSessionPressed -= Quit;
        SceneManager.sceneLoaded -= OnLoadSceneBehaviour;
        GameEvents.OnCustomEvent -= CustomEventBehviour;
    }

    private void LoadSceneByLevelNumber(int level)
    {
        _level = level;

        SceneManager.LoadScene(level);
        OnLoadScene?.Invoke();
    }

    private void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void TryAgain()
    {
        Debug.Log("Try Again");
        LoadSceneByLevelNumber(1);
    }
}
