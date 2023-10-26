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
    [SerializeField] SaveFileManagement saveFileManagement;
    [SerializeField] CharacterRandomisation[] customers;

    private bool isPaused;

    void Start()
    {
        isPaused = false;
        saveFileManagement.OpenFiles();
        RandomiseCustomers();
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

        if (menu == 9 || menu == 10)
        {
            saveFileManagement.UpdateSaveSlotMenu();
        }

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
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void RandomiseCustomers()
    {
        foreach (CharacterRandomisation customer in customers)
        {
            customer.StartAndRandomiseCharacter();
        }
    }
}
