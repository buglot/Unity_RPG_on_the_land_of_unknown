using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar2D : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI text; 
    // Method to update the health bar slider value
    void Start(){
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth *100;
        text.text = healthSlider.value.ToString();
    }
}
