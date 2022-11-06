using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                openpauseMenu();
            }
            
        }
    }

    void openpauseMenu()
    {
        Time.timeScale = 0;
        pMenu.SetActive(true);
        isPaused = true;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pMenu.SetActive(false);
        isPaused = false;
    }

    public void exittoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void exittoDesk()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
