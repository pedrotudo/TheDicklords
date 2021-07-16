using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomDialog : MonoBehaviour
{
    public string[] Dialogs;
    public TextMeshProUGUI TextLabel;
    public float TimeBetween = 3f;

    private void Start()
    {
        StartCoroutine(DialogChange());
    }

    IEnumerator DialogChange()
    {
        while (true)
        {
            TextLabel.text = Dialogs[Random.Range(0, Dialogs.Length)];
            yield return new WaitForSeconds(TimeBetween);
        }
    }
}
