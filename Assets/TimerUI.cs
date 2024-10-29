using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        text.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (minutes == 10 && seconds == 0)
        {
            SceneManager.LoadScene("Play Agian");

        }
    }

}
