using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject panel;
    bool show = false;
    void Start()
    {
        
    }
    public UnityEvent OnPause;
    public UnityEvent UnPause;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            panel.SetActive(!show);
            if(!show){
                OnPause.Invoke();
            }else{
                UnPause.Invoke();
            }
            show = !show;
        }
    }
    public void ShowPanelPause(bool a) { 
        panel.SetActive(a);
        
    }
}
