using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mute : MonoBehaviour
{
    // Start is called before the first frame update
    public string unmute;
     public string mute1;
    void Start()
    {
        textMeshProUGUI.text = unmute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public TextMeshProUGUI textMeshProUGUI;
    bool mute = false;
    public void SetMute()
    {
        if (!mute){
            textMeshProUGUI.text = mute1;
        }else{
            textMeshProUGUI.text = unmute;
        }
        mute = !mute;
    }
}
