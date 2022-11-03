using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] P1Characters;
    public GameObject[] P2Characters;
    public GameObject LevelSelect;
    public GameObject firstcharacteroption;
    private LevelSelection lS;

    public int selectedCharacter = 0;
    public int P2selectedCharacter = 0;
    private int Scenetoload;



    bool player1Ready = false;
    bool player2Ready = false;


    void Start() 
    {
        lS = LevelSelect.GetComponent<LevelSelection>();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            NextCharacter();
        }
    }

    public void setfirstoption()
    {
        //clear Eventsystem Current Selection
         EventSystem.current.SetSelectedGameObject(null);
        //Set new selected option
        EventSystem.current.SetSelectedGameObject(firstcharacteroption);
    }

    public void NextCharacter()
    {
        P1Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % P1Characters.Length;
        P1Characters[selectedCharacter].SetActive(true);
    }

    public void PrevCharacter()
    {
        P1Characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += P1Characters.Length;
        }
        P1Characters[selectedCharacter].SetActive(true);
    }
    
    public void P2NextCharacter()
    {
        P2Characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter = (P2selectedCharacter + 1) % P2Characters.Length;
        P2Characters[P2selectedCharacter].SetActive(true);
    }

    public void P2PrevCharacter()
    {
        P2Characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter--;
        if (P2selectedCharacter < 0)
        {
            P2selectedCharacter += P2Characters.Length;
        }
        P2Characters[P2selectedCharacter].SetActive(true);
    }

    public void P1CharacterSelect()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        player1Ready = true;
        StartGame();

    }

    public void P2CharacterSelect()
    {
        PlayerPrefs.SetInt("P2selectedCharacter", P2selectedCharacter);
        player2Ready = true;
        StartGame();
    }

    public void StartGame()
    {
        if (player2Ready == true && player1Ready == true)
        {
            SceneManager.LoadScene(lS.selectedLevel);
        }
        else 
        {
            return;
        }
    }


}
