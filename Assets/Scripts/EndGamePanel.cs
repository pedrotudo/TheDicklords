using DG.Tweening;
using System;
using UnityEngine;

public class EndGamePanel : Panel
{
    public static Action OnEndSessionPressed;
    public static Action OnSessionRestartPressed;

    public override void Hide()
    {
        PanelContent.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InQuint).SetDelay(0).OnComplete(()=>
        {
            PanelContent.SetActive(false);
        });
    }

    public override void Show()
    {
        PanelContent.SetActive(true);
        PanelContent.transform.localScale = Vector3.zero;
        PanelContent.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuint).SetDelay(0.5f);
    }

    public void TryAgain()
    {
        OnSessionRestartPressed?.Invoke();
        Hide();
    }

    public void EndSession()
    {
        OnEndSessionPressed?.Invoke();
    }
}
