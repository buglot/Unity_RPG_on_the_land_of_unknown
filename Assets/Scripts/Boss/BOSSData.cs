using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BOSSData : ScriptableObject
{
    public string Name;
    public GameObject prefeb;
    public BossState state;
    public EnemyState enemyState;
    public ItemDropState Itemstate;
}
