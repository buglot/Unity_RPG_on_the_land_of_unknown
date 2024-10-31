using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
[Serializable]
public class ItemDropState{
    public float percent_Heartdrop = 20f;
    public float percent_Expdrop = 70f;
    public float health = 10f;
    public int exp = 1;

    public ItemDropState(float percent_Heartdrop,float percent_Expdrop,float health,int exp)
    {
        this.percent_Expdrop = percent_Expdrop;
        this.percent_Heartdrop = percent_Heartdrop;
        this.health = health;
        this.exp = exp;
    }
    public ItemDropState(ItemDropState item)
    {
        this.percent_Expdrop =item. percent_Expdrop;
        this.percent_Heartdrop =item. percent_Heartdrop;
        this.health = item.health;
        this.exp = item.exp;
    }

    public void ApplyProgress(float progress)
    {
        this.exp += (int)(exp * progress*0.1f);
        this.health = health * progress;
        if(this.health>500){health=500f;}
    }
}
public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;  // Heart prefab
    [SerializeField] private GameObject expPrefab;    // Exp prefab
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] public ItemDropState item;
    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTransform = GetComponent<Transform>();
    }
    public void setState(ItemDropState item){
        this.item = new ItemDropState(item.percent_Heartdrop,item.percent_Expdrop,item.health,item.exp);
    }
    public void Drop()
    {
        // Random value between 0 and 100 to determine the drop
        float randomValue = UnityEngine.Random.Range(0f, 100f);

        if (randomValue < item.percent_Heartdrop)
        {
            // 20% chance to drop a Heart

            GameObject a = Instantiate(heartPrefab, _enemyTransform.position, Quaternion.identity);
            Heart b = a.GetComponent<Heart>();
            b.health = item.health;
        }
        else if (randomValue < item.percent_Expdrop)
        {
            // 50% chance to drop Exp (20% + 50% = 70%)
            GameObject a= Instantiate(expPrefab, _enemyTransform.position, Quaternion.identity);
            Experience b = a.GetComponent<Experience>();
            b.exp = item.exp;
        }
        else
        {
            // 30% chance to drop nothing (70% - 100%)
            // No action needed
        }
    }
}



