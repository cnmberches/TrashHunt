using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTutorial : MonoBehaviour
{
    [SerializeField] GameObject CraftingUI, LoloHarmSecondDialogueUI, Tutorial1UI, Tutorial2UI, Tutorial3UI, PencilHolderUI;
    [SerializeField] Button PencilHolderCraftButton;
    [SerializeField] CraftingTableController craftingTableClass;
    [SerializeField] TMP_Text LoloHarmDialogue1, Tutorial1Text, LoloHarmDialogue2, Tutorial2Text, Tutorial3Text, LoloHarmDialogue3, LoloHarmDialogue4, pencilHolderDialog;
    [SerializeField] PlayerController player;
    [SerializeField] GameSettings settings;
    [SerializeField] AudioSource[] englishAudio;
    [SerializeField] AudioSource[] TagalogAudio;

    string[] English_dialogues = {"Here, you can learn how you recycle and reuse trash to help making the world better.",
    "Press the interact button to use the crafting table.",
    "Try crafting the pencil holder.",
    "Press the pencil holder button to interact with.",
    "Press the craft button to craft the item ",
    "By crafting a number of items, you will be able to unlock other craftable items. Also, this will be added to your achievement.",
    "If you need to take a mission or check your achievements, just go to me and press the interact button. I am rooting for you, trash hunter Liam.",
    "Congratulations! You crafted a Pencil Holder!"};

    string[] Filipino_dialogues = { "Dito, pwede kang matuto kung paano mag-recycle at gumamit muli ng mga basura para makatulong ka sa mundo.",
    "Pindutin ang interact button para magamit ang crafting table.",
    "Subukang gawin ang pencil holder.",
    "Pindutin ang pencil holder button para magawa ito.",
    "Pindutin ang craft button para masimula itong gawin.",
    "Sa pag craft ng mga iba't-ibang items, mabubuksan mo pa ang iba pang craftable items. Ito din ay madadagdag sa iyong achievement.",
    "Kung ikaw ay gagawa ng misyon o gusto mong makita ang iyong achievements, pumunta ka lang sa akin at pindutin ang interact button. Nagtitiwala ako sayo, trash hunter Liam.",
    "Binabati kita! Na craft mo na ang Pencil Holder!"};

    private void Start()
    {
        ChangeLanguage(player.language);
    }

    void Update()
    {
        englishAudio[0].volume = player.fxMusicVolume;
        englishAudio[1].volume = player.fxMusicVolume;
        englishAudio[2].volume = player.fxMusicVolume;
        englishAudio[3].volume = player.fxMusicVolume;
        TagalogAudio[0].volume = player.fxMusicVolume;
        TagalogAudio[1].volume = player.fxMusicVolume;
        TagalogAudio[2].volume = player.fxMusicVolume;
        TagalogAudio[3].volume = player.fxMusicVolume;
        if (settings.ChangeInLanguage) 
        {
            ChangeLanguage(player.language);
            settings.ChangeInLanguage = false;
        }

        if (CraftingUI.activeSelf && Tutorial1UI.activeSelf)
        {
            Tutorial1UI.SetActive(false);
            StartCoroutine(LoloHarmSecondDialogue());
        }
        else if(PencilHolderUI.activeSelf && Tutorial2UI.activeSelf)
        {
            Tutorial2UI.SetActive(false);
            Tutorial3UI.SetActive(true);
        }
        else if (PencilHolderUI.activeSelf && !PencilHolderCraftButton.interactable)
        {
            Tutorial3UI.SetActive(false);
            CraftingUI.SetActive(false);
        }
    }

    IEnumerator LoloHarmSecondDialogue()
    {
        LoloHarmSecondDialogueUI.SetActive(true);
        yield return new WaitForSeconds(5);
        LoloHarmSecondDialogueUI.SetActive(false);
        Tutorial2UI.SetActive(true);
    }

    void ChangeLanguage(string language)
    {
        if (language == "filipino")
        {
            LoloHarmDialogue1.text = Filipino_dialogues[0];
            Tutorial1Text.text = Filipino_dialogues[1];
            LoloHarmDialogue2.text = Filipino_dialogues[2];
            Tutorial2Text.text = Filipino_dialogues[3];
            Tutorial3Text.text = Filipino_dialogues[4];
            LoloHarmDialogue3.text = Filipino_dialogues[5];
            LoloHarmDialogue4.text = Filipino_dialogues[6];
            LoloHarmDialogue4.fontSize = 11.5f;
            pencilHolderDialog.text = Filipino_dialogues[7];
            englishAudio[0].mute= true;
            englishAudio[1].mute = true;
            englishAudio[2].mute = true;
            englishAudio[3].mute = true;
        }
        else
        {
            LoloHarmDialogue1.text = English_dialogues[0];
            Tutorial1Text.text = English_dialogues[1];
            LoloHarmDialogue2.text = English_dialogues[2];
            Tutorial2Text.text = English_dialogues[3];
            Tutorial3Text.text = English_dialogues[4];
            LoloHarmDialogue3.text = English_dialogues[5];
            LoloHarmDialogue4.text = English_dialogues[6];
            pencilHolderDialog.text = English_dialogues[7];
            TagalogAudio[0].mute = true;
            TagalogAudio[1].mute = true;
            TagalogAudio[2].mute = true;
            TagalogAudio[3].mute = true;
        }
    }
}
