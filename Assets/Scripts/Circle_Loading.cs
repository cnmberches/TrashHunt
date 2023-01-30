using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Circle_Loading : MonoBehaviour
{
    public TMP_Text text, text2;
    public Image circle;
    public float speed;
    float currentValue;
    float loadingValue = 100;
    public GameObject LoadingPanel, continue_btn, craftingTable_panel, Pencil_holder, Plastic_bottle_pot, Book_Organizer, dialogPencil, dialogPlastic, dialogBook, Analog, interactBtn;
    public PlayerController player;
    public GameObject[] FinishPanel;
   

    void Update()
    {
        if (LoadingPanel.activeSelf)
        {
            StartCoroutine(progress());
        }
        else
        {
            currentValue = 0;
            continue_btn.SetActive(false);
        }
    }

    IEnumerator progress()
    {
        if (currentValue < loadingValue)
        {
            currentValue += speed * Time.deltaTime;
            text.text = ((int)currentValue).ToString() + "%";
        }
        else
        {
            text.text = "100%";
            text2.text = "Recyling Done";
            yield return new WaitForSeconds(1);
            continue_btn.SetActive(true);
        }
        circle.fillAmount = currentValue / loadingValue;
    }

    public void Continue_btn()
    {
        if (Pencil_holder.activeSelf)
        {
            LoadingPanel.SetActive(false);
            craftingTable_panel.SetActive(false);
            Pencil_holder.SetActive(false);
            dialogPencil.SetActive(true);
        }
        else if (Plastic_bottle_pot.activeSelf)
        {
            LoadingPanel.SetActive(false);
            craftingTable_panel.SetActive(false);
            Plastic_bottle_pot.SetActive(false);
            dialogPlastic.SetActive(true);
        }
        else if (Book_Organizer.activeSelf)
        {
            LoadingPanel.SetActive(false);
            craftingTable_panel.SetActive(false);
            Book_Organizer.SetActive(false);
            dialogBook.SetActive(true);
        }
    }
    public void Continue_Exit()
    {
        if(dialogPencil.activeSelf)
        {
            dialogPencil.SetActive(false);
            Analog.SetActive(true) ;
            interactBtn.SetActive(true);
            if (player.StageFinished["House"] && player.CraftedItems["Pencil Holder"] <= 1)
            {
                FinishPanel[0].SetActive(true);
                player.SavePlayer();
            }
        }
        else if (dialogPlastic.activeSelf)
        {
            dialogPlastic.SetActive(false);
            Analog.SetActive(true);
            interactBtn.SetActive(true);
            if (player.StageFinished["Community"] && player.CraftedItems["Plastic Bottle Pot"] == 1)
            {
                FinishPanel[1].SetActive(true);
                player.SavePlayer();
            }
        }
        else if (dialogBook.activeSelf)
        {
            dialogBook.SetActive(false);
            Analog.SetActive(true);
            interactBtn.SetActive(true);
            if (player.StageFinished["School"] && player.CraftedItems["Book Organizer"] == 1)
            {
                FinishPanel[2].SetActive(true);
                player.SavePlayer();
            }
        }
    }

    public void ContinueFinishPanel()
    {
        player.SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
   
