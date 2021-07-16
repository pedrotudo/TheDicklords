using System;

public class MainMenuPanel : Panel
{
    public static Action OnStartPressed;
    public override void Show()
    {
        if (PanelContent != null)
            PanelContent.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        OnStartPressed?.Invoke();
    }

    public override void Hide()
    {
        if (PanelContent != null)
            PanelContent.SetActive(false);
    }
}
