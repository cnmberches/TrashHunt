using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class InteractController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Auntie_deanna, Uncle_larry, Uncle_wayne, loloHarm;
    [SerializeField] GameObject craftingTable;
    [SerializeField] GameObject SchoolLevels, CommunityLevels, ParkLevels;

    public GameObject interact;
    public GameObject JoyStick;
    public GameObject PanelActive;

    private bool isButtonActive = true;

    public void Interact()
    {
        if (player.ObjectCollided != null)
        {
            switch (player.ObjectCollided.tag)
            {
                case "AuntieDeanna":
                    if (player.StageFinished["House"] && player.CraftedItems["Pencil Holder"] >= 1)
                    {
                        CommunityLevels.SetActive(true);
                    }
                    else
                    {
                        Auntie_deanna.SetActive(true);
                        PanelActive = Auntie_deanna;
                    }

                    break;
                case "UncleLarry":
                    if (player.StageFinished["Community" ]&& player.CraftedItems["Plastic Bottle Pot"] >=1)
                    {
                        SchoolLevels.SetActive(true);
                    }
                    else
                    {
                        Uncle_larry.SetActive(true);
                        PanelActive = Uncle_larry;
                    }

                    break;
                case "UncleWayne":
                    if (player.StageFinished["School"] && player.CraftedItems["Book Organizer"] >= 1)
                    {
                        ParkLevels.SetActive(true);
                    }
                    else
                    {
                        Uncle_wayne.SetActive(true);
                        PanelActive = Uncle_wayne;
                    }

                    break;
                case "CraftingTable":
                    craftingTable.SetActive(true);
                    PanelActive = craftingTable;
                    Hidebuttons();
                    break;
                case "LoloHarm":
                        loloHarm.SetActive(true);
                        PanelActive = loloHarm;
                    break;

            }
            isButtonActive = false;
            Hidebuttons();
            player.ObjectCollided = null;
        }
    }
    void Hidebuttons()
    {
        JoyStick.SetActive(false);
        interact.SetActive(false);
    }

    public void Exit()
    {
        PanelActive.SetActive(false);
        JoyStick.SetActive(true);
        interact.SetActive(true);
    }

    private void Update()
   {
        if(isButtonActive && Input.touchCount>0 && (PanelActive != craftingTable))
        {
            Exit();
        }
   }
}
