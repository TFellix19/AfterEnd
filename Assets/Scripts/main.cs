using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.isPaused = false;
        GameManager.npecas = 0;
        SceneManager.LoadScene("Demo-Ilha");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Pause()
    {
        SceneManager.LoadScene("Pause");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        SceneManager.LoadScene("Game");
    }


    public void SureQuit()
    {
        SceneManager.LoadScene("SureQuit");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
