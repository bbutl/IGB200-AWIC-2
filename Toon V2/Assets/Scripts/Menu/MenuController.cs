using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    /*
     * MENU IDs
     * 0 - Main
     * 1 - Options
     * 2 - Sound Options
     * 3 - Other Options
     * 4 - Date Management
     */

    [SerializeField] GameObject[] menus;

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

    public void OpenMenu(int menu)
    {
        ClearMenus();
        menus[menu].SetActive(true);
    }

    private void ClearMenus()
    {
        for (int menu = 0; menu < menus.Length; menu++)
        {
            menus[menu].SetActive(false);
        }
    }

    public void Pause()
    {
        OpenMenu(0);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        ClearMenus();
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
