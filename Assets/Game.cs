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

    private PlayerModel _cachedPlayerModel;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("Awake Game");
        EndGamePanel.OnSessionRestartPressed += TryAgain;
        EndGamePanel.OnEndSessionPressed += Quit;
        SceneManager.sceneLoaded += OnLoadSceneBehaviour;
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
            _cachedPlayerModel = new PlayerModel()
            {
                HP = 100
            };
        }

        InitalizeLevel();
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
    }

    private void LoadSceneByLevelNumber(int level)
    {
        _level = level;

        if (level != 1)
        {
            // cache the current player model to move it to the nexxt level if needed
            _cachedPlayerModel = _playerReference.PlayerModel;
        }

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

    private void InitalizeLevel()
    {
        _playerReference = FindObjectOfType<Player>();
        _playerReference.Initalize(_cachedPlayerModel);
    }

    private void CacheProgression()
    {
        _cachedPlayerModel = _playerReference.PlayerModel;
    }
}
