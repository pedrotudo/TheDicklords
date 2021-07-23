using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHandler : Singleton<PanelsHandler>
{
    public MainMenuPanel MainMenu;
    public InGameHudPanel InGameHud;

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
        MainMenu.Hide();
        InGameHud.Show();
    }

    private void Start()
    {
        MainMenu.Show();
        InGameHud.Hide();
    }

    private void OnPlayerIsDeadBehaviour()
    {
        InGameHud.ShowFail();
    }
}
