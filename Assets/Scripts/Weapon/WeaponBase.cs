using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    public float timeToAttack=1f;
    public float timer;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <0f){
            Attack();
        }
    }
    public abstract void Attack();

    public void SetDamage(Weapon w){
        w.damage = weaponStats.damage;
    }
    public void SetKnockback(Weapon w){
        w.knockback = weaponStats.knockback;
    }
    public void SetAll(Weapon w) {
        SetDamage(w);
        SetKnockback(w);
        SettimeToAttack();
    }
    public void SettimeToAttack(){
        timeToAttack = weaponStats.timeToAttack;
        if(timeToAttack <0.1f){
            timeToAttack = 0.1f;
        }
    }
    public void SettimeToAttack(float a){
        timeToAttack = a;
        if(timeToAttack <0.1f){
            timeToAttack = 0.1f;
        }
    }
    public virtual void SetData(WeaponData wd){
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;
        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack,wd.stats.knockback);
    }

    public void Upgrade(UpGradesData upGradesData)
    {
        weaponStats.Sum(upGradesData.weaponUpgradeState);
        SettimeToAttack(weaponStats.timeToAttack);
    }
}
