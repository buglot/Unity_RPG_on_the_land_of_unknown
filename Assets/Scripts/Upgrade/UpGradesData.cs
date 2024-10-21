using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UpGradesType{
    WeaponUpGrade,
    WeaponUnlock,
    PlayAbilityUpGrade,
    WeaponChange,
}



[CreateAssetMenu]
public class UpGradesData : ScriptableObject
{
    // Start is called before the first frame update
    public UpGradesType UpgradesType;
    public string Name;
    public Sprite card;
    public WeaponData weaponData;
    public WeaponData weaponChangeto;
    public WeaponStats weaponUpgradeState;
    public PlayerStateUpgrade PlayerStateUpgrade;
}
