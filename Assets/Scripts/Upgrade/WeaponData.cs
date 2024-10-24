using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class WeaponStats{
    public float damage;
    public WeaponStats(float damage,float timeToAttack,float knockback){
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.knockback = knockback;
    }
    public float timeToAttack;
    public float knockback;
    public void Sum(WeaponStats weaponStats){
        this.damage += weaponStats.damage;
        this.timeToAttack += weaponStats.timeToAttack;
        this.knockback += weaponStats.knockback;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject prefab;

    public List<UpGradesData> upgradesDatas;
}
