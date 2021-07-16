using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHandler : MonoBehaviour
{
    public static PanelsHandler Instance;
    public MainMenuPanel MainMenu;
    public InGameHudPanel InGameHud;

    private void Awake()
    {
        Instance = this;

        MainMenuPanel.OnStartPressed += OnStartPressedBehaviour;
    }

    private void OnDestroy()
    {
        MainMenuPanel.OnStartPressed -= OnStartPressedBehaviour;
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
}
