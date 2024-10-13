using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2D : MonoBehaviour
{
    public Slider healthSlider;
    
    public TextMeshProUGUI text; 
    // Method to update the health bar slider value
    void Awake(){
        text = GetComponentInChildren<TextMeshProUGUI>();
        
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        if(!health.IsUnityNull())
            text.text = health.ToString();
    }
}
