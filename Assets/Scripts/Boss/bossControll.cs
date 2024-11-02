using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public abstract class BossATKBase : MonoBehaviour
{
    public string Name;

    public abstract void play();
}
public class BossControll : BossBase
{
    // Start is called before the first frame update
    [SerializeField] private List<BossATKBase> action;
    float pretime;
    void Start()
    {
        pretime = stateboss.timer;
        stateboss.timer = float.PositiveInfinity;
        Invoke(nameof(opening), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        stateboss.timer -= Time.deltaTime;
        if (stateboss.timer <= 0f)
        {
            stateboss.timer = stateboss.time;
            attack(Random.Range(0, action.Count));
        }
    }
    public BossATKBase getAction(string name)
    {
        return action.Find(n => n.Name == name);
    }
    public override void opening()
    {
        getAction("superjump").play();
        stateboss.time = pretime;
    }
    public override void attack(int i)
    {
        action[i].play();
    }
}
