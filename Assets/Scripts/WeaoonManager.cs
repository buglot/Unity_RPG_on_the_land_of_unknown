using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaoonManager : MonoBehaviour
{
    [SerializeField] Transform weaponOnjectContainer;
    [SerializeField] WeaponData startingWeapon;
    [SerializeField] List<WeaponBase> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<WeaponBase>();
        AddWeapon(startingWeapon);
        
    }

    // Update is called once per frame
    public void AddWeapon(WeaponData weaponData){
        GameObject weapon = Instantiate(weaponData.prefab, weaponOnjectContainer);
        WeaponBase weaponBase = weapon.GetComponent<WeaponBase>();
        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);
        Level level = GetComponent<Level>();
        if(level!=null){
            level.AddUgradesIntoTheListOfAvilableUpgrades(weaponData.upgradesDatas);
        }
    }

    public void UpgradeWeapon(UpGradesData upGradesData){
        WeaponBase weaponBaseToUpgrade = weapons.Find(wd => wd.weaponData == upGradesData.weaponData);
        weaponBaseToUpgrade.Upgrade(upGradesData);
    }

}
