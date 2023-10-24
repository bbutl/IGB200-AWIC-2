using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    [SerializeField] TextMeshProUGUI nameInput;

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
        Time.timeScale = 0;
        isPaused = true;
        ClearMenus();
        menus[menu].SetActive(true);
    }

    public void PauseAndOpenMenu(int menu)
    {
        OpenMenu(menu);
        Time.timeScale = 0;
        isPaused = true;
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
    }

    public void Resume()
    {
        ClearMenus();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void StartGame()
    {
        Debug.Log(nameInput.text);
        SaveFileManagement.saveFile.playerName = nameInput.text;
        SceneManager.LoadScene("URP");
    }

    public void StartCustomisation()
    {
        SceneManager.LoadScene("Customise");
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
