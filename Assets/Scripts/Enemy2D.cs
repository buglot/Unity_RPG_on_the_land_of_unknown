using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damage = 30f;

    // Reference to the health bar script
    private HealthBar2D healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar2D>();
        if (healthBar != null)
        {
            Debug.Log("Health bar component found!");
            currentHealth = maxHealth;
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
        else
        {
            Debug.LogError("No HealthBar2D component found in children!");
        }


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
        if (a != null)
        {
            TakeDamage(a.damage);
        }
        b = other.gameObject.GetComponent<Player>();
        if (b != null)
        {
            if (b.blood > 0)
                b.TakeDamage(damage);
        }
    }
}
