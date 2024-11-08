using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[Serializable]
public abstract class BossATKBase : MonoBehaviour
{
    public string Name;
    public bool END = true;
    public abstract void play();
    public abstract void Clear();
    public abstract void Cancel();
}
public class BossMain : BossBase
{
    // Start is called before the first frame update
    [SerializeField] private List<BossATKBase> action;
    [SerializeField] BossATKBase NowAction;
    void Start()
    {
        stateboss.timer = float.PositiveInfinity;
        Invoke(nameof(opening), 2f);
    }
    bool beforeOpening = false;
    // Update is called once per frame
    void Update()
    {
        if (NowAction != null)
        {
            if (NowAction.END)
            {
                if (beforeOpening)
                {
                    stateboss.timer = 5;
                    beforeOpening = false;
                }
            }
        }
        stateboss.timer -= Time.deltaTime;
        if (stateboss.timer <= 0f &&!beforeOpening)
        {
            if (NowAction != null)
            {
                if (NowAction.END)
                {
                    stateboss.timer = stateboss.time;
                    attack(Random.Range(0, action.Count));
                }

            }

        }
    }
    public BossATKBase getAction(string name)
    {
        return action.Find(n => n.Name == name);
    }
    public override void opening()
    {
        NowAction = getAction("superjump");
        NowAction.play();
        beforeOpening = true;
    }
    public override void attack(int i)
    {
        NowAction = action[i];
        NowAction.play();
        Debug.Log("ramdom play" + i.ToString());
    }
}
