using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Demo-Ilha");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

     public void SureQuit()
    {
        SceneManager.LoadScene("SureQuit");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        SceneManager.LoadScene("Menu");
    }

    public void QuitApp()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
