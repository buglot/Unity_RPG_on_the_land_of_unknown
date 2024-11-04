using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AudioType{
    Effect,
    UI
}
public class AudioBase : MonoBehaviour
{
    public AudioManager manager;
    public string Name;
    public AudioType type;
    public AudioClip Audio;
    public bool loop = false;
    void Awake(){
        manager = GameObject.FindAnyObjectByType<AudioManager>();
    }
    public void play(){
        manager.Play(this,loop);
    }
}
