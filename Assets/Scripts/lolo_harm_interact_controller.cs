using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lolo_harm_interact_controller : MonoBehaviour
{
    public  GameObject Almanac;
    public GameObject Achievement_Panel, QuizPanel;
    public GameObject MainPanel;
    public InteractController interact;
    public GameObject HouseMission;
   
    public void OpenAchivement()
    {
        Achievement_Panel.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void OpenAlmanac()
    {
        Almanac.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void ExitInteract() 
    {
        MainPanel.SetActive(false);
        interact.interact.SetActive(true);
        interact.JoyStick.SetActive(true);
    }
    public void Mission()
    {
        HouseMission.SetActive(true);
    }
}
