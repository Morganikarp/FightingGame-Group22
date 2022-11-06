using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    public Sprite[] charactersprites;
    public Image P1image;
    public Image P2image;
    public TMP_Text rTimer;
    
    private int selectedCharacter;
    private int P2selectedCharacter;
    private float startingTimer;

    // Start is called before the first frame update
    void Start()
    {   
        startingTimer = PlayerPrefs.GetFloat("roundTimer");
        startTimer();
        setSprites();
    }

    
    private void setSprites()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        P1image.sprite = charactersprites[selectedCharacter];
        P2image.sprite = charactersprites[P2selectedCharacter];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startTimer()
    {
        Debug.Log(startingTimer);
        rTimer.text = "Time Left: " + startingTimer;
    }

}
