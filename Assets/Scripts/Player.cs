using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float blood = 200f;
    public float maxblood;
    public float ammo = 5;
    [SerializeField] HealthBar2D healthBar2D;
    [SerializeField] Level _level;
    [SerializeField] HealthBarUI _healthBarUI;
    AnimeCh anime;

    void Start()
    {
        _healthBarUI = GameObject.FindAnyObjectByType<HealthBarUI>();
        healthBar2D = GetComponentInChildren<HealthBar2D>();
        _level = GetComponentInChildren<Level>();
        maxblood = blood;
        AddBlood(blood);
    }
    public void AddEXP(int e){
        _level.addExperience(e);
    }
    public void AddBlood(float a)
    {
        blood += a;
        if (blood > maxblood)
        {
            blood = maxblood;
        }
        healthBar2D.UpdateHealthBar(blood, maxblood);
        _healthBarUI.UpdateHealthBar(blood, maxblood);
    }
    public UnityEvent OnDie;
    public UnityEvent OnTakeDamage;
    public void TakeDamage(float damage)
    {
        OnTakeDamage.Invoke();
        float plure_damage = damage - (ammo * 2 + ammo);
        if (plure_damage <= 0)
        {
            blood -= 1;
        }
        else if (damage / plure_damage <= 2)
        {
            blood -= plure_damage;
        }
        else
        {
            blood -= plure_damage + (plure_damage - ((ammo - 1) / 2) / 2);
        }
        if (blood <= 0)
        {
            blood = 0;
            OnDie.Invoke();
        }
        healthBar2D.UpdateHealthBar(blood, maxblood);
        _healthBarUI.UpdateHealthBar(blood, maxblood);
    }
}