using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioTriggerType
{
    START,
    CUSTOM_EVENT
}
public class AudioTrigger : MonoBehaviour
{
    public AudioTriggerType TriggerType;
    public string CustomEventName;
    public float PlayDelayTime = 0f;
    AudioSource _audioSource;
    private void Start()
    {
        if (TriggerType == AudioTriggerType.START)
        {
            PlayAudio();
        }
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        GameEvents.OnCustomEvent += CustomEvent;
    }

    private void OnDisable()
    {
        GameEvents.OnCustomEvent += CustomEvent;
    }

    void CustomEvent(string name, string amount)
    {
        if (TriggerType == AudioTriggerType.CUSTOM_EVENT && name == CustomEventName)
        {
            PlayAudio();
        }
    }
    void PlayAudio()
    {
        StartCoroutine(PlayAudioCo());
    }
    IEnumerator PlayAudioCo()
    {
        yield return new WaitForSeconds(PlayDelayTime);
        _audioSource.Play();
    }
}
