using System;
using UnityEngine;
using UnityEngine.Events;


public class Enemy : MonoBehaviour
{

    public EnemyState state;
    public HealthBar2D healthBar;

    void Start()
    {
        if (healthBar == null)
            healthBar = GetComponentInChildren<HealthBar2D>();
        if (healthBar != null)
        {
            state.currentHealth = state.maxHealth;
            healthBar.UpdateHealthBar(state.currentHealth, state.maxHealth);
        }
        else
        {
            Debug.Log("No HealthBar2D component found in children!");
        }


    }
    public HealthBar2D SethealthBar(HealthBar2D SethealthBar)
    {
        healthBar = SethealthBar;
        return healthBar;
    }
    public UnityEvent OnDie;
    public void TakeDamage(float damage)
    {
        state.currentHealth -= damage;
        state.currentHealth = Mathf.Clamp(state.currentHealth, 0, state.maxHealth);

        // Update the health bar
        try{
             healthBar.UpdateHealthBar(state.currentHealth, state.maxHealth);
        }catch(Exception e){
            Debug.Log(e);
        }
       
        if (state.currentHealth <= 0)
        {

            Die();
        }
    }

    void Die()
    {
        // Handle enemy death
        OnDie.Invoke();
        Destroy(gameObject);
    }
    private Weapon a;
    private Player b;
    // If using collision for damage, you can add OnTriggerEnter2D or OnCollisionEnter2D here.
    void OnTriggerEnter2D(Collider2D other)
    {
        a = other.gameObject.GetComponent<Weapon>();
        if (a != null)
        {
            Debug.Log("bbs");
            TakeDamage(a.damage);
        }
        b = other.gameObject.GetComponent<Player>();
        if (b != null)
        {
            if (b.blood > 0)
                b.TakeDamage(state.damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name + " has collided with the edge collider!");
        // Additional logic for handling collision effects
    }
}
