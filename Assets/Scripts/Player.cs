using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float blood = 200f;
    public float maxblood;
    public float ammo = 5;
    [SerializeField] HealthBar2D healthBar2D;
    AnimeCh anime;
    void Start(){
        healthBar2D = GetComponentInChildren<HealthBar2D>();
        maxblood = blood;
        healthBar2D.UpdateHealthBar(blood,maxblood);
        
    }
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
        if( blood<=0){
            blood =0;
            anime = GetComponentInChildren<AnimeCh>();
            anime.setDead(true);
        }
        healthBar2D.UpdateHealthBar(blood,maxblood);
    }
}