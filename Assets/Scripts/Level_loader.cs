using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Level_loader : MonoBehaviour
{
    public GameObject loadingScreen, HouseLevelPanel,JoyStick,interact, SchoolLevelPanel, CommunityLevelPanel, ParkLevelPanel;
    public Button[] Mission;
    public Slider slider;
    public TMP_Text progressTxt;
    public GameObject[] TriviaPanels;
    public PlayerController player;

    public void LoadLevel(string SceneName)
    {
        StartCoroutine(LoadAsynchronously(SceneName));
    }
    IEnumerator LoadAsynchronously(string SceneName)
    {
        loadingScreen.SetActive(true);

        int randomNumber = Random.Range(0, 17);
        TriviaPanels[randomNumber].SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            yield return new WaitForSeconds(1.5f);
            slider.value= progress;
            progressTxt.text = progress * 100f + "%";
            if(progress >= 0.9)
            {
                yield return new WaitForSeconds(2);
                operation.allowSceneActivation = true;
            }
        }
    }
    public void Exit_HouseLevel()
    {
        HouseLevelPanel.SetActive(false);
        JoyStick.SetActive(true);
        interact.SetActive(true);
    }
    public void Exit_SchoolLevel()
    {
        SchoolLevelPanel.SetActive(false);
        JoyStick.SetActive(true);
        interact.SetActive(true);
    }
    public void Exit_CommunityLevel()
    {
        CommunityLevelPanel.SetActive(false);
        JoyStick.SetActive(true);
        interact.SetActive(true);
    }
    public void Exit_ParkLevel()
    {
        ParkLevelPanel.SetActive(false);
        JoyStick.SetActive(true);
        interact.SetActive(true);
    }
    private void Update()
    {
        Mission[0].interactable= true;
        if (player.HouseLevelFinished[1])
        {
            Mission[1].interactable = true;
        }
        if (player.HouseLevelFinished[2])
        {
            Mission[2].interactable = true;
        }
         if (player.HouseLevelFinished[3])
        {
            Mission[3].interactable = true;
        }
         if (player.CommunityLevelFinished[1])
        {
            Mission[4].interactable = true;
        }
         if (player.CommunityLevelFinished[2])
        {
            Mission[5].interactable = true;
        }
        if (player.StageFinished["Community"])
        {
            Mission[6].interactable = true;
        }
        if (player.SchoolLevelFinished[1])
        {
            Mission[7].interactable = true;
        }
        if (player.SchoolLevelFinished[2])
        {
            Mission[8].interactable = true;
        }
        if (player.StageFinished["School"])
        {
            Mission[9].interactable = true;
        }
        if (player.ParkLevelFinished[1])
        {
            Mission[10].interactable = true;
        }
        if (player.ParkLevelFinished[2])
        {
            Mission[11].interactable = true;
        }
    }
}
