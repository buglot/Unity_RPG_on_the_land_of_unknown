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
    public void Play(AudioClip a,float volume){
        audioSource.clip = a;
        audioSource.volume = volume;
    }
}
