using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHandler : Singleton<PanelsHandler>
{
    public InGameHudPanel InGameHud;
    public EndGamePanel EndGame;

    public override void Awake()
    {
        base.Awake();
        Player.OnPlayerIsDead += OnPlayerIsDeadBehaviour;

        InGameHud.Show();
    }

    private void OnDestroy()
    {
    }

    private void OnPlayerIsDeadBehaviour()
    {
        EndGame.Show();
    }
}
