using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    public bool isPaused = false;

    public GameObject pauseMenu;

    private void Update()
    {

        if (Input.GetKeyDown("escape"))
        {

            if (isPaused)
            {

                resume();

            }

            else {

                pause();
            
            }

        }

    }

    public void resume() {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void pause() {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    
    }

    public void quit() {

        Application.Quit();
    
    }

}
