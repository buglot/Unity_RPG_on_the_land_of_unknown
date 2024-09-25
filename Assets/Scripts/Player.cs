using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float blood = 200f;
    public float ammo = 5;

    public void TakeDamage(float damage){
        float plure_damage = damage-(ammo*2+ammo);
        if(damage/plure_damage <=2){
            blood -= plure_damage;
        }else{
            if(plure_damage <=0){
                blood -= 1;
            }else{
                blood -= plure_damage+(plure_damage-((ammo-1)/2)/2);
            }
        }
    }
}