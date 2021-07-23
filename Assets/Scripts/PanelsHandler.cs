using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelsHandler : Singleton<PanelsHandler>
{
    public InGameHudPanel InGameHud;
    public EndGamePanel EndGame;
    public SplashPanel Splash;

    public override void Awake()
    {
        base.Awake();
        Player.OnPlayerIsDead += OnPlayerIsDeadBehaviour;
        SceneManager.sceneLoaded += OnLoadSceneBehaviour;


        InGameHud.Show();
    }

    private void OnLoadSceneBehaviour(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.buildIndex == 1)
        {
            Splash.Show();
            Splash.Hide();
        }
    }

    private void OnDestroy()
    {
        Player.OnPlayerIsDead -= OnPlayerIsDeadBehaviour;
        SceneManager.sceneLoaded -= OnLoadSceneBehaviour;
    }

    private void OnPlayerIsDeadBehaviour()
    {
        EndGame.Show();
    }
}
