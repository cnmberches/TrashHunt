
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlmanaController : MonoBehaviour
{
    public GameObject[] AllPanel = new GameObject[4];
    public GameObject Nextbtn;
    public GameObject Backbtn;
    public GameObject MainPanel;
    public GameObject InteractPanel;
    public PlayerController player;
    public Button[] AlmanacBtn;
    public Almanac almanac;
    int currentPanel = 0;
    int lastPanel = 0;
  
    void Start()
    {
        AllPanel[0].SetActive(true);
    }
   public void Next()
    {
        lastPanel= currentPanel;
        AllPanel[lastPanel].SetActive(false);
        currentPanel++;
        AllPanel[currentPanel].SetActive(true);
        Backbtn.SetActive(true);
        
        if(currentPanel== AllPanel.Length-1)
        {
            Nextbtn.SetActive(false);
        }
    }

    public void Back()
    {
        lastPanel = currentPanel;
        AllPanel[lastPanel].SetActive(false);
        currentPanel--;
        AllPanel[currentPanel].SetActive(true);
        Nextbtn.SetActive(true);
        if(currentPanel == 0) 
        {
            Backbtn.SetActive(false);
        }
    }
    public void Exit()
    {
        MainPanel.SetActive(false);
        InteractPanel.SetActive(true);
    }
    void Update()
    {
      
        if (player.TrashEncountered["Banana Peel"] == true)
        {
            AlmanacBtn[0].interactable = true;
        }
        if (player.TrashEncountered["Plastic Bottles"] == true)
        {
            AlmanacBtn[1].interactable = true;
        }
        if (player.TrashEncountered["Can"] == true)
        {
            AlmanacBtn[2].interactable = true;
        }
        if (player.TrashEncountered["Rotten Carrot"] == true)
        {
            AlmanacBtn[3].interactable = true;
        }
        if (player.TrashEncountered["Plastic"] == true)
        {
            AlmanacBtn[4].interactable = true;
        }
        if (player.TrashEncountered["Rotten Banana"] == true)
        {
            AlmanacBtn[5].interactable = true;
        }
        if (player.TrashEncountered["Rotten Food"] == true)
        {
            AlmanacBtn[6].interactable = true;
        }
        if (player.TrashEncountered["Crumpled Paper"] == true)
        {
            AlmanacBtn[7].interactable = true;
        }
        if (player.TrashEncountered["Tetra pack"] == true)
        {
            AlmanacBtn[8].interactable = true;
        }
        if (player.TrashEncountered["Orange peel"] == true)
        {
            AlmanacBtn[9].interactable = true;
        }
        if (player.TrashEncountered["Candy Wrapper"] == true)
        {
            AlmanacBtn[10].interactable = true;
        }
        if (player.TrashEncountered["Tiolet Paper"] == true)
        {
            AlmanacBtn[11].interactable = true;
        }
        if (player.TrashEncountered["Dried Leaf"] == true)
        {
            AlmanacBtn[12].interactable = true;
        }
        if (player.TrashEncountered["Paper Bag"] == true)
        {
            AlmanacBtn[13].interactable = true;
        }
        if (player.TrashEncountered["Jar"] == true)
        {
            AlmanacBtn[14].interactable = true;
        }
        if (player.TrashEncountered["Box"] == true)
        {
            AlmanacBtn[15].interactable = true;
        }
        if (player.TrashEncountered["Styro Cup"] == true)
        {
            AlmanacBtn[16].interactable = true;
        }
        if (player.TrashEncountered["Tire"] == true)
        {
            AlmanacBtn[17].interactable = true;
        }
    }
}
