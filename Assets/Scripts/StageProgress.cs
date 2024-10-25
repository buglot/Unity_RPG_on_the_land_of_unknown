using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class StageProgressData{
    public float progressTimeRate;
    public float progressPerSplit;

    public StageProgressData(float progressTimeRate,float progressPerSplit)
    {
        this.progressPerSplit = progressPerSplit;
        this.progressTimeRate = progressTimeRate;
    }
}
public class StageProgress : MonoBehaviour
{
    [SerializeField] StageTime stageTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float progressTimeRate = 10f;
    public float progressPerSplit = 0.2f;
    // Update is called once per frame
    public float Progress{
        get{
            return stageTime.time/progressTimeRate *progressPerSplit;
        }
     
    }
}
