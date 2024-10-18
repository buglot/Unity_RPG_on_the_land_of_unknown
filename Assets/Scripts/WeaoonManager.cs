using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaoonManager : MonoBehaviour
{
    [SerializeField] Transform weaponOnjectContainer;
    [SerializeField] WeaponData startingWeapon;
    // Start is called before the first frame update
    void Start()
    {
        AddWeapon(startingWeapon);
    }

    // Update is called once per frame
    public void AddWeapon(WeaponData weaponData){
        GameObject weapon = Instantiate(weaponData.prefab, weaponOnjectContainer);
        weapon.GetComponent<WeaponBase>().SetData(weaponData);
        Level level = GetComponent<Level>();
        if(level!=null){
            level.AddUgradesIntoTheListOfAvilableUpgrades(weaponData.upgradesDatas);
        }
    }

}
