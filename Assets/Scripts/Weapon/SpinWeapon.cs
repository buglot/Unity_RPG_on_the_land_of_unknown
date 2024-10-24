using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : WeaponBase
{
    // Start is called before the first frame update
    [SerializeField] Transform spin;
    [SerializeField] Weapon[] weapons;
    void Start()
    {
        SetAll();
    }
    public void SetAll(){
        foreach(Weapon w in weapons){
            w.damage = weaponStats.damage;
            w.knockback = weaponStats.knockback;
        }
    }
    // Update is called once per frame
    void Update()
    {
        spin.Rotate(Vector3.forward * Time.deltaTime * timeToAttack);
    }
    public  override void Attack(){

    }
}
