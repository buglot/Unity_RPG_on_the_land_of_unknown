using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    int level = 1;
    public int experience = 0;
    [SerializeField] ExperienceBar _experiencebar;
    [SerializeField] LevelupManager lvlupPanel;
    [SerializeField] private List<LevelPlayerDataUpgrade> levelPlayerDataUpgrades;
    [SerializeField] private List<UpGradesData> upgrades;
    [SerializeField] private List<UpGradesData> selectUpgrades;
    [SerializeField] List<UpGradesData> acquireUpgrades;
    [SerializeField] WeaoonManager weaoonManager;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        weaoonManager = GetComponent<WeaoonManager>();
    }
    void Start()
    {
        _experiencebar = GameObject.FindAnyObjectByType<ExperienceBar>();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        _experiencebar.SetTextLevel(level);
        lvlupPanel = GameObject.FindAnyObjectByType<LevelupManager>();
        Levelupgrade();
    }
    private void addLevelNew(LevelPlayerDataUpgrade a)
    {
        upgrades.AddRange(a.upgradesDatas);
        levelPlayerDataUpgrades.Remove(a);
    }
    public void addExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }
    public UnityEvent OnLvlup;
    public void CheckLevelUp()
    {

        if (experience >= TO_LEVEL_UP)
        {
            if (selectUpgrades == null)
            {
                selectUpgrades = new List<UpGradesData>();
            }

            selectUpgrades.Clear();
            selectUpgrades.AddRange(GetUpgrades(4));
            experience -= TO_LEVEL_UP;
            OnLvlup.Invoke();
            if (selectUpgrades.Count >= 1)
                lvlupPanel.Show(selectUpgrades);
            level += 1;
            _experiencebar.SetTextLevel(level);
            Levelupgrade();
        }
    }
    public void Levelupgrade()
    {
        LevelPlayerDataUpgrade a = levelPlayerDataUpgrades.Find(a => a.level == level);
        if (a != null)
        {
            addLevelNew(a);
        }
    }
    public List<UpGradesData> GetUpgrades(int cout)
    {
        List<UpGradesData> upgradeslist = new List<UpGradesData>();
        if (cout > upgrades.Count)
        {
            cout = upgrades.Count;
        }
        for (int i = 0; i < cout; i++)
        {
            upgradeslist.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }
        return upgradeslist;
    }
    // Update is called once per frame
    public void Upgrade(int pressedid)
    {
        UpGradesData upgradedata = selectUpgrades[pressedid];
        if (acquireUpgrades == null) { acquireUpgrades = new List<UpGradesData>(); }
        acquireUpgrades.Add(upgradedata);

        Condition(upgradedata);
        upgrades.Remove(upgradedata);
    }


    private void Condition(UpGradesData data)
    {
        switch (data.UpgradesType)
        {
            case UpGradesType.WeaponUpGrade:
                doWeaponUpGrade(data);
                break;
            case UpGradesType.WeaponUnlock:
                doWeaponUnlock(data);
                break;
            case UpGradesType.PlayAbilityUpGrade:
                doPlayAbilityUpGrade(data);
                break;
            case UpGradesType.WeaponChange:
                doWeaponChange(data);
                break;
        }
    }
    private void doPlayAbilityUpGrade(UpGradesData data)
    {
        Player player = GetComponent<Player>();
        player.Upgrade(data.PlayerStateUpgrade);
    }
    private void doWeaponChange(UpGradesData data)
    {
        weaoonManager.ChangeWeapon(data);
        upgrades.Remove(data);
        List<UpGradesData> a = upgrades.FindAll(wd => wd.weaponData == data.weaponData);
        for (int i = 0; i < a.Count; i++)
        {
            // Clone the UpGradesData so that the file isn't modified
            UpGradesData clonedUpgrades = Clone(a[i]);
            clonedUpgrades.weaponData = data.weaponChangeto;

            // Update the list with the cloned version
            int index = upgrades.IndexOf(a[i]);
            if (index != -1)
            {
                upgrades[index] = clonedUpgrades;  // Replace the original in the list
            }
        }
    }
    public UpGradesData Clone(UpGradesData original)
    {
        UpGradesData clone = ScriptableObject.CreateInstance<UpGradesData>();
        clone.UpgradesType = original.UpgradesType;
        clone.Name = original.Name;
        clone.card = original.card;
        clone.weaponData = original.weaponData;
        clone.weaponChangeto = original.weaponChangeto;
        clone.weaponUpgradeState = original.weaponUpgradeState;
        clone.PlayerStateUpgrade = original.PlayerStateUpgrade;

        return clone;
    }
    private void doWeaponUpGrade(UpGradesData data)
    {
        weaoonManager.UpgradeWeapon(data);
    }
    private void doWeaponUnlock(UpGradesData data)
    {
        weaoonManager.AddWeapon(data.weaponData);
    }
    public void AddUgradesIntoTheListOfAvilableUpgrades(List<UpGradesData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }
}
