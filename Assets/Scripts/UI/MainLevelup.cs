using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainLevelup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    [SerializeField] PauseManager p;
    [SerializeField] List<UpgradeButton> UpgradeButtons;
    void Start(){
        p = GetComponent<PauseManager>();
    }
    public void Show(List<UpGradesData> datas){
        panel.SetActive(true);
        p.Pause();
        for(int i=0;i<datas.Count;i++){
            UpgradeButtons[i].Set(datas[i]);
        }
    }

    public void Upgrade(int pressedid){
        Hide();
    }
    public void Hide(){
        panel.SetActive(false);
        p.unPause();
    }
}
