using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public GameObject pausemenu;

    public GameObject settingsmenu;

    public GameObject sureWantQuit;

    void Start()
    {
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
        sureWantQuit.SetActive(false);
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;

            if (isPaused)
            { 
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
        GameManager.InvAberto = false;
        GameManager.Inv.SetActive(false);
        pausemenu.SetActive(true);
        GameManager.podedisparar = false;

    }
    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
        pausemenu.SetActive(false);
        GameManager.podedisparar = true;
    }
    public void QuitToMenu()
    {
        GameManager.npecas = 0;
        SceneManager.LoadScene("Menu");
    }
    public void SureUWantQuit()
    {
        sureWantQuit.SetActive(true);
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        sureWantQuit.SetActive(false);
        pausemenu.SetActive(false);
        settingsmenu.SetActive(true);
    }

    public void CloseSettings()
    {
        sureWantQuit.SetActive(false);
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false); 
    }
    public void SureUWantQuitNO()
    {
        sureWantQuit.SetActive(false);
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false);
    }
    public void SureUWantQuitYES()
    {
        Application.Quit();
    }
}


   

