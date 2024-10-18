using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    int level = 1;
    public int experience = 0;
    [SerializeField] ExperienceBar _experiencebar;
    [SerializeField] MainLevelup lvlupPanel;
    [SerializeField] private List<UpGradesData> upGradesDatas;
    int TO_LEVEL_UP{
        get{
            return level*1000;
        }
    }
    
    // Start is called before the first frame update
    void Start(){
        _experiencebar = GameObject.FindAnyObjectByType<ExperienceBar>();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        _experiencebar.SetTextLevel(level);
        lvlupPanel= GameObject.FindAnyObjectByType<MainLevelup>();
    }
    public void addExperience(int amount){
        experience += amount;
        CheckLevelUp();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }
    public UnityEvent OnLvlup;
    public void CheckLevelUp(){
        if(experience>=TO_LEVEL_UP){
            experience -= TO_LEVEL_UP;
            OnLvlup.Invoke();
            lvlupPanel.Show(GetUpgrades(4));
            level += 1;
            _experiencebar.SetTextLevel(level);
        }
    }

    public List<UpGradesData>GetUpgrades(int cout){
        List<UpGradesData> upgradeslist = new List<UpGradesData>();
        if(cout>upGradesDatas.Count){
            cout = upGradesDatas.Count;
        }
        for(int i=0;i<cout;i++){
            upgradeslist.Add(upGradesDatas[Random.Range(0, upGradesDatas.Count)]);
        }
        return upgradeslist;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
