using UnityEngine;
using UnityEngine.Events;

public class EnemyState{
    
    public float currentHealth;
    public float damage = 30f;
}
public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public EnemyState state;
    public EnemyDifficultData[] difficultDatas;

    private HealthBar2D healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar2D>();
        if (healthBar != null)
        {
            state.currentHealth = maxHealth;
            healthBar.UpdateHealthBar(state.currentHealth, maxHealth);
        }
        else
        {
            Debug.LogError("No HealthBar2D component found in children!");
        }


    }
    public UnityEvent OnDie;
    public void TakeDamage(float damage)
    {
        state.currentHealth -= damage;
        state.currentHealth = Mathf.Clamp(state.currentHealth, 0, maxHealth);

        // Update the health bar
        healthBar.UpdateHealthBar(state.currentHealth, maxHealth);

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
            TakeDamage(a.damage);
        }
        b = other.gameObject.GetComponent<Player>();
        if (b != null)
        {
            if (b.blood > 0)
                b.TakeDamage(state.damage);
        }
    }
}
