using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SegregationController : MonoBehaviour
{
    public List<GameObject> trashList;
    public GameObject SegregationPanel;
    public Image trashImageUI;
    public TMP_Text ScoreUI;
    public TMP_Text numberOfItems;
    public TMP_Text TrashName;
    public GameObject[] StarsAnimation;
    public GameObject StageClearedUI, stageFinishedPanel;
    public GameObject check, wrong;
    public Button Biobtn, nonBioBtn;
    public GameObject RewardUI;
    public PlayerController player;
    public GameSettings settings;
    public string trashReward;
    public int trashRewardAmount;
    public string stage;
    public int level, starsGained;
    public AudioSource CorrectFX, WrongFX;

    private int TrashIndex = 0;
    private int NumCorrectAnswers = 0;
    private int DisplayedTrash = 0;
    private int NumberOfTrashes = 0;
    private string[] BiodegradableTags = {"Banana Peel", "Rotten Banana", "Orange peel", "Box", "Crumpled Paper", "Dried Leaf", "Tiolet Paper", "Paper Bag", "Rotten Food", "Rotten Carrot", "Pizza Box" };
    private string[] NonBiodegradableTags = { "Can", "Plastic Bottles", "Candy Wrapper", "Jar", "Plastic", "Styro Cup", "Tetra pack", "Tire" };
    private bool isSegregationFinished = false;
    private bool HouseStarsAll3, CommunityStarsAll3, SchoolStarsAll3, ParkAll3;

    void Awake()
    {
        trashList = new List<GameObject>();
    }

    void Update()
    {
        HouseStarsAll3 = player.HouseStarsGained[1] == 3 && player.HouseStarsGained[2] == 3 && player.HouseStarsGained[3] == 3;
        CommunityStarsAll3 = player.CommunityStarsGained[1] == 3 && player.CommunityStarsGained[2] == 3 && player.CommunityStarsGained[3] == 3;
        SchoolStarsAll3 = player.SchoolStarsGained[1] == 3 && player.SchoolStarsGained[2] == 3 && player.SchoolStarsGained[3] == 3;
        ParkAll3 = player.ParkStarsGained[1] == 3 && player.ParkStarsGained[2] == 3 && player.ParkStarsGained[3] == 3;

        if (trashList.Count != 0)
        {
            NumberOfTrashes = trashList.Count;
            if (TrashIndex == 0)
            {
                UpdateUI();
            }
        }

        if (TrashIndex > (NumberOfTrashes - 1) && isSegregationFinished)
        {
            StartCoroutine(CloseSegregation());
        }

        if(isSegregationFinished)
        {
            ScoreUI.text = "Score: " + NumCorrectAnswers;
            Biobtn.interactable = false;
            nonBioBtn.interactable = false;
        }
    }

    public void ContinueBtnStars()
    {
        if (player.isTutorialFinished)
        {
            switch (stage)
            {
                case "House":
                    player.HouseLevelFinished[level] = true;
                    if (player.HouseStarsGained[level] < starsGained)
                    {
                        player.HouseStarsGained[level] = starsGained;
                        player.SavePlayer();
                    }
                    break;
                case "School":
                    player.SchoolLevelFinished[level] = true;
                    if (player.SchoolStarsGained[level] < starsGained)
                    {
                        player.SchoolStarsGained[level] = starsGained;
                        player.SavePlayer();
                    }
                    break;
                case "Park":
                    player.ParkLevelFinished[level] = true;
                    if (player.ParkStarsGained[level] < starsGained)
                    {
                        player.ParkStarsGained[level] = starsGained;
                        player.SavePlayer();
                    }
                    break;
                case "Community":
                    player.CommunityLevelFinished[level] = true;
                    if (player.CommunityStarsGained[level] < starsGained)
                    {
                        player.CommunityStarsGained[level] = starsGained;
                        player.SavePlayer();
                    }
                    break;
            }
        }
        RewardUI.SetActive(true);
        player.CollectedTrash[trashReward] += trashRewardAmount;
    }

    public void ContinueBtnReward()
    {
        if (player.isTutorialFinished)
        {
            switch (stage)
            {
                case "House":
                    if (player.CraftedItems["Pencil Holder"] >= 1 && HouseStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                        StartCoroutine(TimeActive());
                    }
                    else if (HouseStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                    }
                    break;
                case "Community":
                    if (player.CraftedItems["Plastic Bottle Pot"] >= 1 && CommunityStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                        stageFinishedPanel.SetActive(true);
                    }
                    else if (CommunityStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                    }
                    break;
                case "School":
                    if (player.CraftedItems["Book Organizer"] >= 1 && SchoolStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                        stageFinishedPanel.SetActive(true);
                    }
                    else if (SchoolStarsAll3)
                    {
                        player.StageFinished[stage] = true;
                    }
                    break;
                case "Park":
                    if (ParkAll3)
                    {
                        player.StageFinished[stage] = true;
                        player.isOnBase = true;
                        player.SavePlayer();
                        SceneManager.LoadScene("Cutscene_Last");
                    }
                    else
                    {
                        Save();
                    }
                    break;
            }
            if (!stageFinishedPanel.activeSelf)
            {
                Save();
            }
        }

        else
        {
            player.SavePlayer();
            SceneManager.LoadScene("CraftingTutorial");
        }
    }

    IEnumerator CloseSegregation()
    {
        yield return new WaitForSeconds(2);
        SegregationPanel.SetActive(false);

        double ThreeStar = Math.Round(NumberOfTrashes * 0.75);
        double TwoStar = Math.Round(NumberOfTrashes * 0.50);
        if (NumCorrectAnswers >= ThreeStar)
        {
            //show anim three star
            StageClearedUI.SetActive(true);
            StarsAnimation[2].SetActive(true);
            starsGained = 3;
        }
        else if (NumCorrectAnswers >= TwoStar)
        {
            //show anim two star
            StageClearedUI.SetActive(true);
            StarsAnimation[1].SetActive(true);
            starsGained = 2;
        }
        else if (NumCorrectAnswers < TwoStar && NumCorrectAnswers > 0)
        {
            //show anim one star
            StageClearedUI.SetActive(true);
            StarsAnimation[0].SetActive(true);
            starsGained = 1;
        }
        else
        {
            player.PlayerDeath.SetActive(true);
        }
    }

    IEnumerator TimeActive()
    {
        stageFinishedPanel.SetActive(true);
        yield return new WaitForSeconds(10);
    }

    public void BiodegradableBtn()
    {
        StartCoroutine(Biodegradable());
        if (TrashIndex <= (NumberOfTrashes - 1))
        {
            TrashIndex++;
        }
        if (TrashIndex > (NumberOfTrashes - 1))
        {
            isSegregationFinished = true;
        }
    }

    public void NonBiodegradableBtn()
    {
        StartCoroutine(NonBiodegradable());
        if (TrashIndex <= (NumberOfTrashes - 1))
        {
            TrashIndex++;
        }
        if (TrashIndex > (NumberOfTrashes - 1))
        {
            isSegregationFinished = true;
        }
    }

    private void UpdateUI()
    {
        if (TrashIndex <= (NumberOfTrashes - 1))
        {
            ScoreUI.text = "Score: " + NumCorrectAnswers;
            numberOfItems.text = (DisplayedTrash + 1)+ " / " + trashList.Count;
            TrashName.text = trashList[TrashIndex].tag;
            trashImageUI.sprite = trashList[TrashIndex].gameObject.GetComponent<SpriteRenderer>().sprite;
        }
    }
    IEnumerator Biodegradable()
    {
        if (BiodegradableTags.Contains(trashList[TrashIndex].gameObject.tag))
        {
            CorrectFX.Play();
            Biobtn.interactable = false;
            nonBioBtn.interactable = false;
            check.SetActive(true);
            NumCorrectAnswers++;
            DisplayedTrash++;
            yield return new WaitForSeconds(1);
            UpdateUI();
            check.SetActive(false);
            Biobtn.interactable = true;
            nonBioBtn.interactable = true;
        }
        else
        {
            WrongFX.Play();
            Biobtn.interactable = false;
            nonBioBtn.interactable = false;
            wrong.SetActive(true);
            DisplayedTrash++;
            yield return new WaitForSeconds(1);
            UpdateUI();
            wrong.SetActive(false);
            Biobtn.interactable = true;
            nonBioBtn.interactable = true;
        }
    }
    IEnumerator NonBiodegradable()
    {
        if (NonBiodegradableTags.Contains(trashList[TrashIndex].gameObject.tag))
        {
            CorrectFX.Play();
            Biobtn.interactable = false;
            nonBioBtn.interactable = false;
            check.SetActive(true);
            NumCorrectAnswers++;
            DisplayedTrash++;
            yield return new WaitForSeconds(1);
            UpdateUI();
            check.SetActive(false);
            Biobtn.interactable = true;
            nonBioBtn.interactable = true;
        }
        else
        {
            WrongFX.Play();
            Biobtn.interactable = false;
            nonBioBtn.interactable = false;
            wrong.SetActive(true);
            DisplayedTrash++;
            yield return new WaitForSeconds(1);
            UpdateUI();
            wrong.SetActive(false);
            Biobtn.interactable = true;
            nonBioBtn.interactable = true;
        }
    }
    void Save()
    {
        player.SavePlayer();
        SceneManager.LoadScene("Base");
    }
    public void ContinueAuntie()
    {
        Save();
    }
    public void ContinueUncleLarry()
    {
        Save();
    }
    public void ContinueUncleWayne()
    {
        Save();
    }
    public void ContinueQuiz()
    {
        player.isOnBase = true;
        player.SavePlayer();
        SceneManager.LoadScene("Cutscene_Last");
    }
}
