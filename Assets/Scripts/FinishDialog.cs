using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDialog : MonoBehaviour
{
    private SaveData data;
    [SerializeField] TMP_Text trophy, Loloharm1, Loloharm2, Loloharm3, narrator;
    [SerializeField] AudioSource[] EnglsihAudio;
    [SerializeField] AudioSource[] TagalogAudio;
    [SerializeField] AudioSource bgmusic;

    string[] English_dialogues = {
    "Congratulations! This trophy is for you, for defeating all the trash monsters and cleaning the world!",
    "You did great, my grandson! Even though we have defeated all the trash monsters,",
    " you still have the life mission of keeping your environment clean by throwing your trash in the right bins.",
    "And remember, do not forget to apply the lessons that you have learned in your adventure.",
    "You saved the world! People can now enjoy getting out of their houses without being afraid of the trash monsters or the sickness that they might get from a dirty environment. Just remember that segregating waste is not just a one-time mission. It is a lifetime mission that you need to do every day so that we can keep our environment healthy! Good luck on your next adventure, trash hunter!"};

    string[] Filipino_dialogues = {
    "Congratulations! Ang trophy na ito ay para sa iyo, para sa pagtalo sa lahat ng mga trash monsters at sa paglilinis ng mundo!",
    "Mahusay ang ginawa mo, apo! Kahit na natalo na natin ang trash monsters,",
    " mayroon ka pa ring misyon sa buhay na panatilihing malinis ang iyong kapaligiran sa pamamagitan ng pagtatapon ng iyong basura sa tamang basurahan.",
    "At tandaan, huwag kalimutang isagawa ang mga aral na iyong natutunan sa iyong adventure.", 
        "Iniligtas mo ang mundo! Matutuwa na ang mga tao sa paglabas ng kanilang mga bahay nang hindi natatakot sa mga trash monsters o sa sakit na maaaring makuha nila mula sa isang maruming kapaligiran. Tandaan lamang na ang paghihiwalay ng basura ay hindi lamang isang beses na misyon. Ito ay isang panghabambuhay na misyon na kailangan mong gawin araw-araw upang mapanatiling malusog ang ating kapaligiran! Good luck sa iyong susunod na adventure, trash hunter!"};
    
    void Start()
    {
        bgmusic.volume = data.bgMusicVolume;
        if (data.language.Equals("filipino"))
        {
            trophy.text= Filipino_dialogues[0];
            Loloharm1.text = Filipino_dialogues[1];
            Loloharm2.text = Filipino_dialogues[2];
            Loloharm3.text = Filipino_dialogues[3];
            narrator.text = Filipino_dialogues[4];
            EnglsihAudio[0].mute = true;
            EnglsihAudio[1].mute = true;
            EnglsihAudio[2].mute = true;
            EnglsihAudio[3].mute = true;
            EnglsihAudio[4].mute = true;
        }
        else
        {
            trophy.text = English_dialogues[0];
            Loloharm1.text = English_dialogues[1];
            Loloharm2.text = English_dialogues[2];
            Loloharm3.text = English_dialogues[3];
            narrator.text = English_dialogues[4];
            TagalogAudio[0].mute = true;
            TagalogAudio[1].mute = true;
            TagalogAudio[2].mute= true;
            TagalogAudio[3].mute = true;
            TagalogAudio[4].mute = true;
        }
    }

    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }
    public void GameisDone()
    {
        SaveSystem.Delete();
        SceneManager.LoadScene("Start Menu");
    }
}
