using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar2D : MonoBehaviour
{
    public Slider healthSlider;

    // Method to update the health bar slider value
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth *100;
    }
}
