using System;

public static class GameEvents
{
    public static Action<string,string> OnCustomEvent;
    public static void CustomEvent(string name, string amount)
    {
        OnCustomEvent?.Invoke(name, amount);
    }
}
