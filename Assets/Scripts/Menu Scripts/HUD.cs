using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    public Sprite[] charactersprites;
    public GameObject[] characterprefabs;
    public Image P1image;
    public Image P2image;
    public TMP_Text P1name;
    public TMP_Text P2name;
    public TMP_Text rTimer;
    public TMP_Text rNumber;
    
    private int selectedCharacter;
    private int P2selectedCharacter;
    public static float startingTimer;
    public static float currentTime = 0f;
    private float roundNumber;
    

    // Start is called before the first frame update
    void Start()
    {   
        startingTimer = SettingsMenu.roundTimer;
        currentTime = startingTimer;
        roundNumber = RoundManager.roundsleft;
        setSprites();
        setnames();
    }

        // Update is called once per frame
    void Update()
    {
        startTimer();
        displayroundNumber();
    }

    private void displayroundNumber()
    {
        rNumber.text = "Round: " + roundNumber;
    }

    private void startTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        currentTime = Mathf.Round(currentTime * 1000f) / 1000f;
        rTimer.text = "Time Left: " + currentTime;
    }

    private void setSprites()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        P1image.sprite = charactersprites[selectedCharacter];
        P2image.sprite = charactersprites[P2selectedCharacter];      
    }

    private void setnames()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        P1name.text = "Player 2: " + characterprefabs[selectedCharacter].name;
        P2name.text = "Player 1: " + characterprefabs[P2selectedCharacter].name;      
    }


}
