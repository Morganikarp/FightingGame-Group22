using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstmain;
    public GameObject firstmainreopen;

    public void PlayGame() 
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 ); 
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void OptionsMenu() 
    {
        GetComponent<Canvas>().enabled = false;
    }

    public void reopenMain()
    {
        //clear Eventsystem Current Selection
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstmainreopen);
    }
}
