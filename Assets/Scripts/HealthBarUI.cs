using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _textlevel;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _textlevel = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateExperienceSlider(float current, float target)
    {
        _slider.maxValue = target;
        _slider.value = current;
        SetText(current);
    }
    public void SetText(float blood){
        _textlevel.text = ((int)blood).ToString();
    }


}
