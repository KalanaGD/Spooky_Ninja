using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }


    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

/*
 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 * this code for load the next level
 
 
  
*/