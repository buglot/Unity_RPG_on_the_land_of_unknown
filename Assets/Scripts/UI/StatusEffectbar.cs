using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectbar : MonoBehaviour
{
    [SerializeField] GameObject layout;
    [SerializeField] Dictionary<string,StatusItem> statusItems;
    [SerializeField] GameObject prefeb;
    void Start(){
        statusItems = new Dictionary<string, StatusItem>();
    }
    // Start is called before the first frame update
    public void AddObject(StatusItemData a)
    {
        StatusItem ck_status = null;
        if(statusItems.TryGetValue(a.Name,out ck_status)){
            ck_status.setTime(a.time);
            return;
        }
        GameObject status = Instantiate(prefeb, layout.transform);
        StatusItem status1 = status.GetComponent<StatusItem>();
        status1.SetImage(a.image);
        status1.DestroySelf(a.destory);
        status1.setTime(a.time);
        status1.SetColorBg(a.bgcolor);
        status1.SetColorCooldown(a.cooldowncolor);
        status1.SetStatusEffectbar(this); 
        status1.Name = a.Name;
        statusItems.Add(a.Name,status1);
    }
    public void KillWithString(string a){
        statusItems.Remove(a);
    }
}
