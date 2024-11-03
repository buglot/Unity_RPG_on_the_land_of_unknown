using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelupManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public Level player;
    [SerializeField] PauseManager p;
    [SerializeField] List<UpgradeButton> UpgradeButtons;
    [SerializeField] public TextMeshProUGUI textTitle;
    
    void Start(){
        p = GetComponent<PauseManager>();
        player = GameObject.FindAnyObjectByType<Level>();
    }
    public void Show(List<UpGradesData> datas){
        Clear(); 
        panel.SetActive(true);
        p.Pause();
        for(int i=0;i<datas.Count;i++){
            UpgradeButtons[i].gameObject.SetActive(true);
            UpgradeButtons[i].Set(datas[i]);
        }
    }

    public void Upgrade(int pressedid){
        Hide();
        player.Upgrade(pressedid);
    }
    public void Hide(){
        foreach(UpgradeButton button in UpgradeButtons){
            button.gameObject.SetActive(false);
        }
        panel.SetActive(false);
        p.unPause();
    }

    public void Clear(){
        foreach(UpgradeButton button in UpgradeButtons){
            button.Clear();
        }
    }
}
