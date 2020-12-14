using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    private int scene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            } 
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (scene != 0)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void QuitGame()
    {
        FindObjectOfType<EndGame>().Reset();
    }
}
