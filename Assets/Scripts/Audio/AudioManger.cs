using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<EffectAudioSource> audios;

    public void Play(AudioBase audioBase)
    {
        // Calculate volume based on the AudioType
        float volume = VolumeOfType(audioBase.type);

        // Find an available EffectAudioSource that is not playing
        EffectAudioSource availableSource = audios.Find(source => source.finish);

        // If no available source is found, find the one playing the longest and use that
        if (availableSource == null)
        {
            availableSource = FindLongestPlayingAudio();
            if (availableSource == null) return; // No source available, exit if all are busy
        }

        // Play the audio on the available or longest-playing source
        availableSource.Play(audioBase.audioSource, volume);
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
}

