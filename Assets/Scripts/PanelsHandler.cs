using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHandler : Singleton<PanelsHandler>
{
    public MainMenuPanel MainMenu;
    public InGameHudPanel InGameHud;
    public EndGamePanel EndGame;

    public override void Awake()
    {
        MainMenuPanel.OnStartPressed += OnStartPressedBehaviour;
        Player.OnPlayerIsDead += OnPlayerIsDeadBehaviour;
    }

    private void OnDestroy()
    {
        MainMenuPanel.OnStartPressed -= OnStartPressedBehaviour;
        Player.OnPlayerIsDead -= OnPlayerIsDeadBehaviour;
    }

    private void OnStartPressedBehaviour()
    {
        EndGame.Hide();
        MainMenu.Hide();
        InGameHud.Show();
    }

    private void Start()
    {
        MainMenu.Show();
        InGameHud.Hide();
        EndGame.Hide();
    }

    private void OnPlayerIsDeadBehaviour()
    {
        EndGame.Show();
    }
}
