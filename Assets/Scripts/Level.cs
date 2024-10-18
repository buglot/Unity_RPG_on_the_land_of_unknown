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
    void Awake(){
        weaoonManager = GetComponent<WeaoonManager>();
    }
    void Start()
    {
        _experiencebar = GameObject.FindAnyObjectByType<ExperienceBar>();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        _experiencebar.SetTextLevel(level);
        lvlupPanel = GameObject.FindAnyObjectByType<LevelupManager>();
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
            lvlupPanel.Show(selectUpgrades);
            level += 1;
            _experiencebar.SetTextLevel(level);
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
                Debug.Log("gogogogogoog");
                doWeaponUnlock(data);
                break;
        }
    }
    private void doWeaponUpGrade(UpGradesData data)
    {

    }
    private void doWeaponUnlock(UpGradesData data){
        weaoonManager.AddWeapon(data.weapon);
    }
    public void AddUgradesIntoTheListOfAvilableUpgrades(List<UpGradesData> upgradesToAdd){
        this.upgrades.AddRange(upgradesToAdd);
    }
}
