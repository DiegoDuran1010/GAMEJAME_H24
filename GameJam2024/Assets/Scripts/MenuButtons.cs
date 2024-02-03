using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    //Load la scene du menu au level 1
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit le jeu
   public void Quit()

    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
