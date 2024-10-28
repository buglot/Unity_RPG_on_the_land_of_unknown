using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float blood = 200f;
    public float maxblood;
    public float armor = 5;
    [SerializeField] HealthBar2D healthBar2D;
    [SerializeField] Level _level;
    [SerializeField] HealthBarUI _healthBarUI;
    [SerializeField] PlayerCharacter_Controller movement;
    [SerializeField] Magnet magnet;
    [SerializeField] StatusEffectbar effectbar;
    public void AddStatusBar(StatusItemData a){
        effectbar.AddObject(a);
    }
    AnimeCh anime;
    float timer;
    bool was_Attacked = false;
    public float time_was_Attacked_by_enemy = 1f;
    public void UseMegnet(float time){
        magnet.SetTimeUse(time);
    }
    void Awake(){
        _healthBarUI = GameObject.FindAnyObjectByType<HealthBarUI>();
    }
    void Start()
    {
        
        healthBar2D = GetComponentInChildren<HealthBar2D>();
        _level = GetComponent<Level>();
        movement = GetComponent <PlayerCharacter_Controller>();
        maxblood = blood;
        AddBlood(blood);
        timer = time_was_Attacked_by_enemy;
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
    void Update(){
        if(was_Attacked){
            timer -= Time.deltaTime;
            if(timer < 0f){
                was_Attacked = !was_Attacked;
                timer = time_was_Attacked_by_enemy;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (!was_Attacked)
        {
            OnTakeDamage.Invoke();

            float plure_damage = damage - (armor * 2 + armor);
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
                blood -= plure_damage + (plure_damage - ((armor - 1) / 2) / 2);
            }
            if (blood <= 0)
            {
                blood = 0;
                OnDie.Invoke();
            }
            UpdateHealth();
            was_Attacked = true;
        }
    }
    public void UpdateHealth(){
        if (blood>maxblood){
            blood = maxblood;
        }
        healthBar2D.UpdateHealthBar(blood, maxblood);
        _healthBarUI.UpdateHealthBar(blood, maxblood);
    }
    public void Upgrade(PlayerStateUpgrade playerState){
        this.blood += playerState.health;
        this.maxblood += playerState.maxblood;
        this.armor += playerState.armor;
        this.movement.MoveSpeed += playerState.MoveSpeed;
        UpdateHealth();
    }

}