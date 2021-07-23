using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameHudPanel : Panel
{
    public Slider HpSlider;
    public TMP_Text Level;

    public override void Hide()
    {
        if (PanelContent != null)
            PanelContent.SetActive(false);
    }

    public override void Show()
    {
        if (PanelContent != null)
            PanelContent.SetActive(true);
    }

    private void Awake()
    {
        Player.OnPlayerHitpointsChange += UpdateSlider;
        Game.OnLoadScene += UpdateLevelLabel;
    }

    private void OnDestroy()
    {
        Player.OnPlayerHitpointsChange -= UpdateSlider;
        Game.OnLoadScene -= UpdateLevelLabel;
    }

    private void UpdateSlider(int currentHitpoints)
    {
        HpSlider.value = currentHitpoints;
    }

    private void UpdateLevelLabel()
    {
        Level.text = $"Stage 0{Game.Instance.Level}";
    }
}
