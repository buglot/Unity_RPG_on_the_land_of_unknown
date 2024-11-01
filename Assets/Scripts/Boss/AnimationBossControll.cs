using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

[Serializable]
public class AnimationTypeControll{
    public string Name;
    public Animator anime;

    public AnimationTypeControll(string name,Animator a)
    {
        Name = name;
        anime = a;
    }
}
public class AnimationBossControll : MonoBehaviour
{
    [SerializeField] private Animator nomalAnime;
    [SerializeField] private List<AnimationTypeControll> atkAnime;
    // Start is called before the first frame update
    void Start()
    {
        getAnime("shield").anime.Play("shield");
    }
    public AnimationTypeControll getAnime(string name) {
        foreach (AnimationTypeControll a in atkAnime) {
            if (a.Name == name){
                return a;
            }
        }
        return null;
    }
    public void getAnimePlay(string name, string Play) {
        foreach (AnimationTypeControll a in atkAnime) {
            if (a.Name == name){
                a.anime.Play(Play,0);
                break;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
