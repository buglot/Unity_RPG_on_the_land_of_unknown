using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
   public void StartGameplay()
   {
        SceneManager.LoadScene("helfgame");
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
