using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class bossATKBase : MonoBehaviour{
    public string Name;

    public abstract void play();
}
public class bossControll : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<bossATKBase> action;
    float timer;
    float time;
    void Start()
    {
        Invoke(nameof(opening),3f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public bossATKBase getAction(string name){
        return action.Find(n=>n.Name == name);
    }
    void opening(){
       getAction("superjump").play();
    }
}
