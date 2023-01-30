using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsTracker : MonoBehaviour
{
    public GameObject[] ClaimBtn;
    public GameObject[] listOfAchivement;
    public GameObject Analog, interact, Panel;
    public PlayerController player;

    void Start()
    {
        if (player.CraftedItems["Pencil Holder"] == 1 || player.CraftedItems["Plastic Bottle Pot"] == 1 || player.CraftedItems["Book Organizer"] == 1 && player.AchievementList["Newbie Crafter"] == false)
        {
            ClaimBtn[0].SetActive(false);
        }
        //Check if House is finish so the Community is open
        if (player.StageFinished["House"] == true)
        {
            ClaimBtn[1].SetActive(false);
        }
        // Check if Community is finish so the School is open
        if (player.StageFinished["Community"] == true)
        {
            ClaimBtn[2].SetActive(false);
        }
        //Check if the School is finished so the Park is open
        if (player.StageFinished["School"] == true)
        {
            ClaimBtn[3].SetActive(false);
        }
        //check if the player is already crafted all the items
        if (player.CraftedItems["Pencil Holder"] >= 1 && player.CraftedItems["Plastic Bottle Pot"] >= 1 && player.CraftedItems["Book Organizer"] >= 1)
        {
            ClaimBtn[4].SetActive(false);
        }

        //check if the player get the newbie achievement
        if (player.AchievementList["Newbie Crafter"] == true)
        {
            Destroy(listOfAchivement[0]);
        }
        if (player.AchievementList["Community is Opened"] == true)
        {
            Destroy(listOfAchivement[1]);
        }
        if (player.AchievementList["School is opened"] == true)
        {
            Destroy(listOfAchivement[2]);
        }
        if (player.AchievementList["Park is Opened"] == true)
        {
            Destroy(listOfAchivement[3]);
        }
        if (player.AchievementList["King of Crafter"] == true)
        {
            Destroy(listOfAchivement[4]);
        }
    }
    public void Craftnewbie()
    {
        player.AchievementList["Newbie Crafter"] = true;
        listOfAchivement[0].SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
        player.SavePlayer();
    }
    public void CommunityisOpened()
    {
        player.AchievementList["Community is Opened"] = true;
        listOfAchivement[1].SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
        player.SavePlayer();
    }

    public void SchoolisOpened()
    {
        player.AchievementList["School is opened"] = true;
        listOfAchivement[2].SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
        player.SavePlayer();
    }
    public void ParkisOpened()
    {
        player.AchievementList["Park is Opened"] = true;
        listOfAchivement[3].SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
        player.SavePlayer();
    }
    public void KingOfCrafter()
    {
        player.AchievementList["King of Crafter"] = true;
        listOfAchivement[4].SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
        player.SavePlayer();
    }
    public void Close()
    {
        Panel.SetActive(false);
        Analog.SetActive(true);
        interact.SetActive(true);
    }
}
