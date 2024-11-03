using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaoonManager : MonoBehaviour
{
    [SerializeField] Transform weaponOnjectContainer;
    [SerializeField] List<WeaponBase> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<WeaponBase>();

    }

    // Update is called once per frame
    public WeaponBase AddWeapon(WeaponData weaponData)
    {
        GameObject weapon = Instantiate(weaponData.prefab, weaponOnjectContainer);
        WeaponBase weaponBase = weapon.GetComponent<WeaponBase>();
        
        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);
        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUgradesIntoTheListOfAvilableUpgrades(weaponData.upgradesDatas);
        }
        return weaponBase;
    }

    public void UpgradeWeapon(UpGradesData upGradesData)
    {
        WeaponBase weaponBaseToUpgrade = weapons.Find(wd => wd.weaponData == upGradesData.weaponData);
        weaponBaseToUpgrade.Upgrade(upGradesData);
    }

    public void ChangeWeapon(UpGradesData upGradesData)
    {
        WeaponBase weaponBaseToUpgrade = weapons.Find(wd => wd.weaponData == upGradesData.weaponData);
        WeaponBase NewWeapon = AddWeapon(upGradesData.weaponChangeto);
        NewWeapon.weaponStats.damage += weaponBaseToUpgrade.weaponStats.damage;
        NewWeapon.weaponStats.knockback += weaponBaseToUpgrade.weaponStats.knockback;
        Destroy(weaponBaseToUpgrade.gameObject);
        weapons.Remove(weaponBaseToUpgrade);
    }
}
