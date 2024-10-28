using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class StatusItemData{
    public float time;
    public bool destory;
    public Sprite image;
    public string Name;
    public Color bgcolor;
    public Color cooldowncolor;
    public StatusItemData(float time,Color bgcolor,Color cooldowncolor,Sprite image,string name,bool destory){
        this.time = time;
        this.destory = destory;
        this.image = image;
        this.bgcolor = bgcolor;
        this.cooldowncolor = cooldowncolor;
        Name = name;
    }
}
public class StatusItem : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public float time;
    public String Name;
    [SerializeField] private Image image;
    [SerializeField] private Image PanelColor;
    [SerializeField] private Image CooldownPanel;
    [SerializeField] private TextMeshProUGUI text;

    public void SetColorBg(Color color){
        PanelColor.color = color;
    }
    public void SetColorCooldown(Color color){
        CooldownPanel.color =color;
    }
    public void SetImage(Sprite sprite){
        image.sprite = sprite;
    }
    public void setTime(float t){
        timer = t;
        time =t;
    }
    [SerializeField] bool kill;
    public void DestroySelf(bool a){
        kill =a;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(timer>0f){
            timer -=Time.deltaTime;
            CooldownPanel.fillAmount = ((time-timer)/time);
            text.text = timer>2f?((int)Math.Ceiling(timer)).ToString():String.Format("{0:F2}",timer<=0?0f:timer);
        }else{
            if(kill){
                statusEffectbar1.KillWithString(Name);
                Destroy(gameObject);
                
            }
        }
    }
    private StatusEffectbar statusEffectbar1;
    public void SetStatusEffectbar(StatusEffectbar statusEffectbar)
    {
        statusEffectbar1 = statusEffectbar;
    }

}
