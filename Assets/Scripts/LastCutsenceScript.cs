using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using TMPro;

public class LastCutsenceScript : MonoBehaviour
{

    private PlayableDirector TimelineDirector;
    private SaveData data;
    [SerializeField] TMP_Text PlayerScript, Loloharm, playerscript2;
    [SerializeField] AudioSource[] EnglsihAudio;
    [SerializeField] AudioSource[] TagalogAudio;
    [SerializeField] AudioSource bgmusic;

    string[] English_dialogues = { "Lolo Haaaarmm!! I did it! We did it! We have successfully defeated the monster and cleaned the world!",
    "You still have one mission to complete, grandson. I have questions for you and you need to pass this quiz to successfully defeat the trash monsters. I hope you learned something on your adventure.",
    "yes, lolo harm. I am ready"};

    string[] Filipino_dialogues = { "Lolo Haaaarmm!! Nagawa ko! Nagawa natin! Matagumpay po nating natalo ang mga trash monster at nalinis ang mundo!",
    "may isa ka pang misyon na dapat tapusin. Para makuha natin ang matagumpay nating panalo mula sa trash monster, mayroon akong ilang katanungan para sa iyo na dapat mong sagutin. Sana may naituro sa iyo ang adventure mo.",
    "Okay po, Lolo Harm! Handa na po ako!!"};

    void Start()
    {
        bgmusic.volume = data.bgMusicVolume;
        EnglsihAudio[0].volume = data.fxMusicVolume;
        EnglsihAudio[1].volume = data.fxMusicVolume;
        EnglsihAudio[2].volume = data.fxMusicVolume;
        TagalogAudio[0].volume = data.fxMusicVolume;
        TagalogAudio[1].volume = data.fxMusicVolume;
        TagalogAudio[2].volume = data.fxMusicVolume;
        if (data.language.Equals("filipino"))
        {
            PlayerScript.text = Filipino_dialogues[0];
            Loloharm.text = Filipino_dialogues[1];
            playerscript2.text = Filipino_dialogues[2];
            EnglsihAudio[0].mute= true;
            EnglsihAudio[1].mute= true;
            EnglsihAudio[2].mute= true;
        }
        else
        {
            PlayerScript.text = English_dialogues[0];
            Loloharm.text = English_dialogues[1];
            playerscript2.text = English_dialogues[2];
            TagalogAudio[0].mute= true;
            TagalogAudio[1].mute= true;
            TagalogAudio[2].mute= true;
        }
    }
    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }
    
    public void ContinueBtn()
    {
        SceneManager.LoadScene("Quiz_assessment");
    }
    public void ClaimTrophy()
    {
        Debug.Log("Done");
    }
}
