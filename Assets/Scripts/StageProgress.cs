using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
    [SerializeField] StageTime stageTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] float progressTimeRate = 10f;
    [SerializeField] float progressPerSplit = 0.2f;
    // Update is called once per frame
    public float Progress{
        get{
            return stageTime.time/progressTimeRate *progressPerSplit;
        }
     
    }
}
