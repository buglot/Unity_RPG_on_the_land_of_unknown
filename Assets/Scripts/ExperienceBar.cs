using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _textlevel;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _textlevel = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateExperienceSlider(int current, int target)
    {
        _slider.maxValue = target;
        _slider.value = current;
    }
    public void SetTextLevel(int level){
        _textlevel.text = "Lavel : " + level.ToString();
    }


}
