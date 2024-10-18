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
        w.damage = weaponData.stats.damage;
    }
    public void SetKnockback(Weapon w){
        w.knockback = weaponData.stats.knockback;
    }
    public void SetAll(Weapon w) {
        SetDamage(w);
        SetKnockback(w);
    }
    public virtual void SetData(WeaponData wd){
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;
        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack,wd.stats.knockback);
    }
    
}
