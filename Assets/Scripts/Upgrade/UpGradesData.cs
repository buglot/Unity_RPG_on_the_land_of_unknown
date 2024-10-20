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
    public UpGradesType UpgradesType;
    public string Name;
    public Sprite card;
    public WeaponData weaponData;
    public WeaponStats weaponUpgradeState;
}
