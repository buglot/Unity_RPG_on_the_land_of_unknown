using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damage = 30f;
    // Reference to the health bar script

    private EnemyHealthBar2D healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar2D>();
        if (healthBar != null)
        {
            Debug.Log("Health bar component found!");
        }
        else
        {
            Debug.LogError("No EnemyHealthBar2D component found in children!");
        }
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death
        Destroy(gameObject);
    }
    private Weapon a;
    private Player b;
    // If using collision for damage, you can add OnTriggerEnter2D or OnCollisionEnter2D here.
    void OnTriggerEnter2D(Collider2D other)
    {
        a = other.gameObject.GetComponent<Weapon>();
        if(a!=null){
            TakeDamage(a.damage);
        }
        b = other.gameObject.GetComponent<Player>();
        if(b!=null){
            b.TakeDamage(damage);
        }
    }
}
