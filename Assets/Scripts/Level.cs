using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar _experiencebar;
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
    }
    public void addExperience(int amount){
        experience += amount;
        CheckLevelUp();
        _experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }
    
    public void CheckLevelUp(){
        if(experience>=TO_LEVEL_UP){
            experience -= TO_LEVEL_UP;
            level += 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
