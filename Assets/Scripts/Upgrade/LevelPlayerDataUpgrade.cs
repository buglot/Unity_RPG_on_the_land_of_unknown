using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPlayerDataUpgrade : ScriptableObject{
    public int level;
    public List<UpGradesData> upgradesDatas;
}