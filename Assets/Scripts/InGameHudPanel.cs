using DG.Tweening;
using System;
using UnityEngine;

public class InGameHudPanel : Panel
{
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
}
