using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour
{
    public GameObject firstleveloption;

    [SerializeField] public int selectedLevel;

    public void SelectFirstStage()
    {
        selectedLevel = 2;
    }
    
    public void SelectSecondStage()
    {
        selectedLevel = 3;
    }

    public void SelectThirdStage()
    {
        selectedLevel = 4;
    }

    public void setfirstoption()
    {
            //clear Eventsystem Current Selection
            EventSystem.current.SetSelectedGameObject(null);
            //Set new selected option
            EventSystem.current.SetSelectedGameObject(firstleveloption);
    }



}
