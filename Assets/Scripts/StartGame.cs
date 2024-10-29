using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class StartGame : MonoBehaviour
{

     
   public UnityEvent OnStart;

   public void StartGameplay()
   {
        SceneManager.LoadScene("helfgame");
        OnStart.Invoke();
   }

   public void BacktoMenu()
   {
        SceneManager.LoadScene("MainMenu");
   }

   public void PlayAgian()
   {
        SceneManager.LoadScene("Play Agian");
   }

   
}
