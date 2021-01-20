﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
        
    }

    public void ResumeGame()
    {
        Debug.Log("ok");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
       
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
}
