using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;

    private bool paused;
    
    public void PauseInput()
    {
        if (!paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }

    private void Start()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }
    
    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;

    }
}
