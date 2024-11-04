using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<EffectAudioSource> audios;

    public void Play(AudioBase audioBase, bool loop)
    {
        // Calculate volume based on the AudioType
        float volume = VolumeOfType(audioBase.type);
        // Find an available EffectAudioSource that is not playing
        EffectAudioSource availableSource = audios.Find(source => source.finish==true && source.audioSource.loop!=true);

        // If no available source is found, find the one playing the longest and use that
        if (availableSource == null)
        {
            Debug.Log("finding");
            availableSource = FindLongestPlayingAudio();
            if (availableSource == null) return;
        }
        // Play the audio on the available or longest-playing source
        availableSource.Play(audioBase.Audio, volume, loop);
    }

    float VolumeOfType(AudioType type)
    {
        float volume = 0;
        switch (type)
        {
            case AudioType.Effect:
                volume = AudioInterface.volumeEffect / AudioInterface.volumeMain;
                break;
            case AudioType.UI:
                volume = AudioInterface.volumeUI / AudioInterface.volumeMain;
                break;
        }
        return volume;
    }
    private EffectAudioSource FindLongestPlayingAudio()
    {
        float maxPlayTime = 0f;
        EffectAudioSource longestPlayingSource = null;

        foreach (EffectAudioSource source in audios)
        {
            if (!source.finish && source.audioSource.time > maxPlayTime)
            {
                maxPlayTime = source.audioSource.time;
                longestPlayingSource = source;
            }
        }
        return longestPlayingSource;
    }

    bool mute = false;
    public void SetMute()
    {
        if (!mute){
            AudioInterface.volumeEffect = 0;
            
        }else{
            AudioInterface.volumeEffect = 0.5f;
        }
        mute = !mute;
    }
    
}

