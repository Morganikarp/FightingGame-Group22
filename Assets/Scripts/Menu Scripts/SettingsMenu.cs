using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public Slider sliderUI;
    private TMP_Text textSliderValue;
    public GameObject firstoptions;

    Resolution[] resolutions;

    bool isFullscreen;
    public int roundNumber = 0;
    public int roundTimer = 0;

    void Start()
    {
        showResolutions();
    }

    private void showResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions(); //Clears options in the dropdown
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz"; ;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        textSliderValue = GetComponent<TMP_Text>();
        ShowSliderValue();
    }

    private void ShowSliderValue()
    {
        string sliderMessage = "" + sliderUI.value;
        textSliderValue.text = sliderMessage;
    }


    public void setfirstoption()
    {
        //clear eventsystem
        EventSystem.current.SetSelectedGameObject(null);
        //Set new eventsystem selected button
        EventSystem.current.SetSelectedGameObject(firstoptions);
    }
    
    public void SetResolution (int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullscreen, resolution.refreshRate);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //Toggles Fullscreen when toggle button is pressed
    }

    public void SetGraphics (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
    }

    public void SetRoundnumber()
    {
        PlayerPrefs.SetInt("roundNumber", roundNumber);
    }
    public void SetRoundTimer()
    {
        PlayerPrefs.SetInt("roundTimer", roundTimer);
    }
}
