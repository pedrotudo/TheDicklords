using System;
using UnityEngine;

public class InGameHudPanel : Panel
{
    public GameObject FailPanel;

    public static Action OnEndSessionPressed;

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

    public void ShowFail()
    {
        FailPanel.SetActive(true);
    }

    public void EndSession()
    {
        OnEndSessionPressed?.Invoke();
    }
}
