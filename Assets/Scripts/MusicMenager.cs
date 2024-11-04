using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnStart;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Play(musicOnStart, true);
    }


    AudioClip switchTo;
    public void Play(AudioClip music, bool interrupt = false)
    {
        if(interrupt == true)
        {
            volume = 0.25f;
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();
        }
        else
        {
            switchTo = music;
            StartCoroutine(SmoothSwitchMusic());
        }
        
    }

    float volume = 0.25f;
    [SerializeField] float TimeToSwitch;
    bool mute = false;
    public void SetMute()
    {
        if (!mute){
            volume  = 0;
            audioSource.Stop();
        }else{
            volume = 0.25f;
            Start();
        }
        mute = !mute;
    }
    IEnumerator SmoothSwitchMusic()
    {
        volume = 0.25f;

        while (volume > 0f)
        {
            volume -= Time.deltaTime / TimeToSwitch;
            if(volume < 0f )
            {
                volume = 0f;
            }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

        Play(switchTo, true);

    }
    
}
