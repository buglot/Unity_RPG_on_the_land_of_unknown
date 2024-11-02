using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BossState{
    public float playerknock;
    public float time;
    public float timer{ get; set; }
}
public abstract class BossBase : Enemy{

    public EnemySpawner spawner;
    public BossState stateboss;
    public ItemDrop item;
    public GameObject HealthBar;
    public abstract void attack(int i);
    public abstract void opening();
    public void SetState(BossState a,EnemyState est){
        state.damage = est.damage;
        state.speed = est.speed;
        state.maxHealth = est.maxHealth;
        state.currentHealth = est.currentHealth;
        stateboss.playerknock = a.playerknock;
        stateboss.time = a.time;
        
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