using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TMP_Text Label;


    private Color _red = Color.red;
    private Color _green = Color.green;

    public void Run(int value)
    {
        Label.gameObject.SetActive(true);

        Color originColor = value < 0 ? _red : _green;

        Label.color = new Color(originColor.r, originColor.g, originColor.b, 1);

        Color targetColor = new Color(originColor.r, originColor.g, originColor.b, 0);

        Label.text = value.ToString();
        Label.transform.position = new Vector3(Label.transform.position.x, Label.transform.position.y, Label.transform.position.z + 1.5f);
        Label.transform.DOMove(new Vector3(Label.transform.position.x, Label.transform.position.y, Label.transform.position.z + 2), 1).OnComplete(()=> {
            Label.gameObject.SetActive(false);
        });
        Label.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 0.3f);

        Label.DOColor(targetColor, 1);
    }
}
