using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar2D : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI text; 
    // Method to update the health bar slider value
    void Awake(){
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth *100;
        if(!health.IsUnityNull())
            text.text = health.ToString();
    }
}
