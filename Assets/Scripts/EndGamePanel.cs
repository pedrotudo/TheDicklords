using DG.Tweening;
using System;
using UnityEngine;

public class EndGamePanel : Panel
{
    public static Action OnEndSessionPressed;
    public static Action OnSessionRestartPressed;

    public override void Hide()
    {
        PanelContent.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InQuad).SetDelay(0).OnComplete(()=>
        {
            PanelContent.SetActive(false);
        });
    }

    public override void Show()
    {
        PanelContent.SetActive(true);
        PanelContent.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutQuad).SetDelay(2);
    }

    public void TryAgain()
    {
        OnSessionRestartPressed?.Invoke();
    }

    public void EndSession()
    {
        OnEndSessionPressed?.Invoke();
    }
}
