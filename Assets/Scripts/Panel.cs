using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public GameObject PanelContent;

    public abstract void Show();
    public abstract void Hide();

}
