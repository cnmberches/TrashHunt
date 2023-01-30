using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftingTableController : MonoBehaviour
{
    public GameObject timeline2;
    public PlayerController player;
    public TMP_Text PencilHolderCollectedMaterials, PlasticBottlePotCollectedMaterials, BookOrganizerCollectedMaterials;
    public Button PencilHolderBtn, PlasticBottlePotBtn, BookOrganizerBtn;
    public GameObject crafting_loading;
  
    private void Update()
    {
        if (player.CollectedTrash["Plastic Bottles"] >= 4)
        {
            PencilHolderBtn.interactable = true;
        }
        else
        {
            PencilHolderBtn.interactable = false;
        }

        if (player.CollectedTrash["Plastic Bottles"] >= 5)
        {
            PlasticBottlePotBtn.interactable = true;
        }
        else
        {
            PlasticBottlePotBtn.interactable = false;
        }

        if (player.CollectedTrash["Box"] >= 5)
        {
            BookOrganizerBtn.interactable = true;
        }
        else
        {
            BookOrganizerBtn.interactable = false;
        }

        PencilHolderCollectedMaterials.text = player.CollectedTrash["Plastic Bottles"].ToString();
        PlasticBottlePotCollectedMaterials.text = player.CollectedTrash["Plastic Bottles"].ToString();
        BookOrganizerCollectedMaterials.text = player.CollectedTrash["Box"].ToString();

        if(!player.isTutorialFinished && timeline2.activeInHierarchy && timeline2.GetComponent<PlayableDirector>().time >= 39)
        {
            player.isTutorialFinished = true;
            player.SavePlayer();
            SceneManager.LoadScene("Base"); 
        }
    }

    public void PencilHolderBtnFunc()
    {
        
        player.CraftedItems["Pencil Holder"] += 1;
        player.CollectedTrash["Plastic Bottles"] -= 4;
        player.SavePlayer() ;
        crafting_loading.SetActive(true);
    }

    public void PlasticBottlePotFunc()
    {
        player.CraftedItems["Plastic Bottle Pot"] += 1;
        player.CollectedTrash["Plastic Bottles"] -= 5;
        player.SavePlayer() ;
        crafting_loading.SetActive(true);
    }

    public void BookOrganizerFunc()
    {
        player.CraftedItems["Book Organizer"] += 1;
        player.CollectedTrash["Box"] -= 4;
        player.SavePlayer();
        crafting_loading.SetActive(true);
    }

    public void TutorialClose()
    {
        timeline2.SetActive(true);
    }
    
    void CheckReq()
    {
        if (player.HouseLevelFinished[3] && player.CraftedItems["Pencil Holder"] > 1)
        {
            player.StageFinished["House"] = true;
        }
        else if (player.CommunityLevelFinished[3] && player.CraftedItems["Plastic Bottle Pot"] > 1)
        {
            player.StageFinished["Community"] = true;
        }
        else if (player.SchoolLevelFinished[3] && player.CraftedItems["Book Organizer"] > 1)
        {
            player.StageFinished["School"] = true;
        }
    }
}
