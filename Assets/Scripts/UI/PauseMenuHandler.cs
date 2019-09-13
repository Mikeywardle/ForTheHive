using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    private bool paused;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            processPause();
        }
    }

    private void processPause()
    {
        if (paused)
            unpause();
        else
            pause();

        paused = !paused;
    }

    public void pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void unpause()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
