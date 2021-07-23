using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomNoiseManager : MonoBehaviour
{
    public AudioSource[] RandomNoises;
    public float MaxRndTime = 5f;
    public float MinRndTime = 2f;
    private void Start()
    {
        if (RandomNoises.Length == 0)
        {
            RandomNoises = GetComponentsInChildren<AudioSource>().ToArray();
            foreach (var item in RandomNoises)
            {
                item.playOnAwake = false;
                item.loop = false;
            }
        }
        StartCoroutine(RandomNoisesCo());
    }

    IEnumerator RandomNoisesCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomTime());
            var rndNoise = GetRandomNoise();
            if(rndNoise != null)
                rndNoise.Play();
        }
    }

    float GetRandomTime()
    {
        return Random.Range(MinRndTime, MaxRndTime);
    }
    AudioSource GetRandomNoise()
    {
        AudioSource value = null;

        if (RandomNoises != null && RandomNoises.Length > 0)
        {
            value = RandomNoises[Random.Range(0, RandomNoises.Length)];
        }

        return value;
    }

}
