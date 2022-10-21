using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    bool isFullscreen;

    void Start()
    {
     resolutions = Screen.resolutions;
     resolutionDropdown.ClearOptions(); //Clears options in the dropdown
     List<string> options = new List<string>();
     int currentResolutionIndex = 0;
     for(int i=0; i <resolutions.Length; i++)
     {
         string option = resolutions[i].width + " x " + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz";;
         options.Add(option);
        if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
         {
             currentResolutionIndex = i;
         }
     }
     resolutionDropdown.AddOptions(options);
     resolutionDropdown.value = currentResolutionIndex;
     resolutionDropdown.RefreshShownValue();
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

}
