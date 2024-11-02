using System;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class EnemyState
{
    public EnemyState(float blood,float maxHealth, float damage, float speed)
    {
        currentHealth = blood;
        this.damage = damage;
        this.speed = speed;
        this.maxHealth = maxHealth;
    }

    public EnemyState(EnemyState state)
    {
        this.currentHealth = state.currentHealth;
        this.damage = state.damage;
        this.speed = state.speed;
        maxHealth = state.maxHealth;
    }


    public float currentHealth;
    public float maxHealth;
    public float damage;
    public float speed;

    public void ApplyProgress(float progress)
    {
        this.currentHealth += (int)(currentHealth * progress);
        this.maxHealth = this.currentHealth;
        this.damage += (float)(damage * progress);
    }
}
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string Name;
    public GameObject prefeb;
    public EnemyState state;
    public ItemDropState Itemstate;
}
