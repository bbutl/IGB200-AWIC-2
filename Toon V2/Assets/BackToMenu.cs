using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public DayController day;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(day.day == 6)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
