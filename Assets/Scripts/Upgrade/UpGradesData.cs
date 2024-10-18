using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpGradesType{
    WeaponUpGrade,
    WeaponUnlock,
}


[CreateAssetMenu]
public class UpGradesData : ScriptableObject
{
    // Start is called before the first frame update
    public UpGradesType upGradesType;
    public string Name;
    public GameObject card;
}
