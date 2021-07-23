using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashPanel : Panel
{
    public Image Splash;
    public override void Hide()
    {
        Splash.DOFade(0, 2).SetDelay(2).OnComplete(()=> {
            PanelContent.SetActive(false);
        });
    }

    public override void Show()
    {
        PanelContent.SetActive(true);
        Splash.DOFade(1, 0);
    }
}
