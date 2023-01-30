using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToTutorialController : MonoBehaviour
{
    [SerializeField] GameObject Transition;
    [SerializeField] TMP_Text IntroductionNarration1, IntroductionNarration2, IntroductionNarration3,
        LoloHarmDialogue1, LoloHarmDialogue2, CharacterDialogue1, CharacterDialogue2;
    [SerializeField] AudioSource[] englishAudio;
    [SerializeField] AudioSource[] TagalogAudio;
    [SerializeField] AudioSource bgMusic;
    private SaveData data;
    private string[] IntroductionFilipinoDialogues = 
        { "Trash monsters, ito ay ang mga kalaban na nabuo dahil sa kapabayaan ng mga tao sa mga basura. Isang hero lang ang makakatalo sa kanila at siya ay si Liam.",
    "Si Liam ay apo ni Lolo Harm. Siya ay isang elementary school student na nakatira sa Baranggay Idiyanale..",
    "At mayroon siyang misyon na talunin ang mga trash monster para maiwasan ang mga iba't-ibang masamang pangyayari sa mundo.",
    "Apo, ito na ang oras mo para iligtas ang mundo. Ituturo ko sayo ang lahat para matalo ang mga trash monster at malinis ang mundo",
    "Natatakot po ako, Lolo Harm. Pero gagawin ko po ang best ko.",
    "Handa ka na ba?",
    "Opo!!"};
    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }

    private void Start()
    {
        bgMusic.volume = data.bgMusicVolume;
        englishAudio[0].volume = data.fxMusicVolume;
        englishAudio[1].volume = data.fxMusicVolume;
        englishAudio[2].volume = data.fxMusicVolume;
        englishAudio[3].volume = data.fxMusicVolume;
        englishAudio[4].volume = data.fxMusicVolume;
        englishAudio[5].volume = data.fxMusicVolume;
        englishAudio[6].volume = data.fxMusicVolume;
        TagalogAudio[0].volume = data.fxMusicVolume;
        TagalogAudio[1].volume = data.fxMusicVolume;
        TagalogAudio[2].volume = data.fxMusicVolume;
        TagalogAudio[3].volume = data.fxMusicVolume;
        TagalogAudio[4].volume = data.fxMusicVolume;
        TagalogAudio[5].volume = data.fxMusicVolume;
        TagalogAudio[6].volume = data.fxMusicVolume;
        if (data.language.Equals("filipino"))
        {
            IntroductionNarration1.text = IntroductionFilipinoDialogues[0];
            IntroductionNarration2.text = IntroductionFilipinoDialogues[1];
            IntroductionNarration3.text = IntroductionFilipinoDialogues[2];
            LoloHarmDialogue1.text = IntroductionFilipinoDialogues[3];
            LoloHarmDialogue2.text = IntroductionFilipinoDialogues[5];
            CharacterDialogue1.text = IntroductionFilipinoDialogues[4];
            CharacterDialogue2.text = IntroductionFilipinoDialogues[6];
            englishAudio[0].mute= true;
            englishAudio[1].mute = true;
            englishAudio[2].mute = true;
            englishAudio[3].mute = true;
            englishAudio[4].mute = true;
            englishAudio[5].mute = true;
            englishAudio[6].mute = true;


        }
        else
        {
            TagalogAudio[0].mute= true;
            TagalogAudio[1].mute= true;
            TagalogAudio[2].mute = true;
            TagalogAudio[3].mute = true;
            TagalogAudio[4].mute = true;
            TagalogAudio[5].mute = true;
            TagalogAudio[6].mute = true;
        }
    }


    void Update()
    {
        if (Transition.activeSelf)
        {
            StartCoroutine(GoToTutorial());
        }
    }

    IEnumerator GoToTutorial()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("TutorialForGame");
    }

}
