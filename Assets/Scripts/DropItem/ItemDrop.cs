using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;  // Heart prefab
    [SerializeField] private GameObject expPrefab;    // Exp prefab
    [SerializeField] private EnemyManager _enemy;
    [SerializeField] private Transform _enemyTransform;
    public float dropHeart = 20f;
    public float health = 10f;
    public int exp = 1;
    public float dropExp = 70f;
    void Awake()
    {
        _enemy = GetComponent<EnemyManager>();
        _enemyTransform = GetComponent<Transform>();
    }

    public void Drop()
    {
        // Random value between 0 and 100 to determine the drop
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < dropHeart)
        {
            // 20% chance to drop a Heart

            GameObject a = Instantiate(heartPrefab, _enemyTransform.position, Quaternion.identity);
            Heart b = a.GetComponent<Heart>();
            b.health = health;
        }
        else if (randomValue < dropExp)
        {
            // 50% chance to drop Exp (20% + 50% = 70%)
            GameObject a= Instantiate(expPrefab, _enemyTransform.position, Quaternion.identity);
            Experience b = a.GetComponent<Experience>();
            b.exp = exp;
        }
        else
        {
            // 30% chance to drop nothing (70% - 100%)
            // No action needed
        }
    }
}



