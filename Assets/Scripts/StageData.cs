using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class StageEvent
{
    public float time;
    public string message;
}

[CreateAssetMenu]

public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;
}
