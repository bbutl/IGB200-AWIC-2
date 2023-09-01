using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("URP");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
