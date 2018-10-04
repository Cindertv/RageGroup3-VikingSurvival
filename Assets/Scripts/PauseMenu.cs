using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;

    private bool paused = false;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void Resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

    }

}
