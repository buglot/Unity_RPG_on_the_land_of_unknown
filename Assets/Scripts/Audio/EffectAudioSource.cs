using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioSource : MonoBehaviour
{
    public AudioSource audioSource;
    public bool finish;
    void Update()
    {
        finish = !audioSource.isPlaying;
    }
    public void Play(AudioClip a, float volume, bool loop)
    {
        audioSource.clip = a;
        audioSource.volume = volume;
        audioSource.loop = loop;
        Debug.Log(audioSource.clip.name);
        audioSource.Play();
        finish = false;
    }
}
