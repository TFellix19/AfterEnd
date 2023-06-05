using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public GameObject pausemenu;
   
    void Update()
    {
       
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausemenu.SetActive(true); // ativa o PauseMenu

    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausemenu.SetActive(false); // desativa o PauseMenu

    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}


   

