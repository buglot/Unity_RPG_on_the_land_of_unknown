using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATKthrow : BossATKBase
{
    public bool isPlay = false;
    [SerializeField] Animator nomalAnime;
    [SerializeField] EnemyData slime_enemy;
    public override void Cancel()
    {
        
    }

    public override void Clear()
    {
        
    }

    public override void play()
    {
        isPlay = true;
        nomalAnime.Play("idle");
        
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(isPlay){
            
        }
    }
}
