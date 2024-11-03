using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BossState{
    public float playerknock;
    public float time;
    public float timer;
    public BossState(BossState a){
        playerknock = a.playerknock;
        time = a.time;
    }
}
public abstract class BossBase : Enemy{

    public EnemySpawner spawner;
    public BossState stateboss;

    public ItemDrop item;
    public GameObject HealthBar;
    public abstract void attack(int i);
    public abstract void opening();
    public void SetState(BossState a,EnemyState est){
        state = new EnemyState(est);
        stateboss = new BossState(a);
    }
    public void dead(){
        spawner.boss = null;
        spawner.nowtype = TypeSpawnEnemy.Nomal;
        HealthBar.SetActive(false);
        
    }
    public void setSpawner(EnemySpawner a){
        spawner = a;
    }
}
