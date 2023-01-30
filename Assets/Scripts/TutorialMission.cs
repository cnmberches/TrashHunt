using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialMission : Mission
{
    [SerializeField] GameObject TutorialJoystick, TutorialAttack, TutorialPickup, SegregationTutorial;
    [SerializeField] GameObject PlayerCharacter, PlayerCharacterForAnimation;
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject PlayerHealthBar;
    [SerializeField] GameObject[] NewTrashPanel;
    [SerializeField] TMP_Text Tutorial1Text, Tutorial2Text, Tutorial3Text, LoloHarmDialogue1, LoloHarmDialogue2, LoloHarmDialogue3, LoloHarmDialogue4, LoloHarmDialogue5,
        NewBananaPeelDialog, NewPlasticBottleDialog, DeathDialog, BiodegradableText, NonBiodegradableText;
    [SerializeField] CameraFollow CameraFollower;
    [SerializeField] JoystickController movementJoystick;
    [SerializeField] PlayerController playerController;
    [SerializeField] AudioSource[] englishAudio;
    [SerializeField] AudioSource[] TagalogAudio;
    [SerializeField] TextMeshProUGUI[] missionText = new TextMeshProUGUI[3];
    [SerializeField] EnemyController[] enemy;
    [SerializeField] GameSettings settingsController;

    private string[] English_dialogues = { "Use the joystick analog to move.",
    "Press the attack button to fire an arrow.",
    "Move to the garbage to collect trash.",
    "Comeback here again, grandson.",
    "Now that I taught you how to defeat trash monsters and collect trash, let us now learn how to segregate them.",
    "Let me explain first to you what is biodegradable and non-biodegradable trash.",
    "Biodegradable wastes is capable of being decomposed by bacteria or other living organisms. An example of biodegradable waste is banana peels.",
    "And the non–biodegradable wastes are waste which cannot be broken down by natural organism. One example of this is plastic bottles.",
    "Banana peel is an example of biodegradable waste.",
    "Plastic bottle is an example of non–biodegradable trash. It takes a 450 years to dissolve. Bottles can be reused or can be turned into a plant pot.",
    "Oh no!! Your lack of effort and knowledge resulted into flood that destroyed houses and bad smell of environment that causes sickness to people. Would you like to try again?",
    "Biodegradable", "Non-biodegradable",
    };

    private string[] Filipino_dialogues = { "Gamitin ang joystick para makagalaw.",
    "Pindutin ang attack button para magamit ang pana.",
    "Lapitan ang basura para makuha ito.",
    "Bumalik ka dito, apo ko.",
    "Ngayon naturo ko na sayo paano talunin ang mga trash monster at kolektahin ang mga basura, ituturo ko naman sayo ay ang pagbubuklod.",
    "Ipapaliwanag ko muna sayo kung ano ang nabubulok at hindi nabubulok na basura",
    "Ang nabubulok na basura ay meron kakayahang mabulok gamit ang mga bakterya. Halimbawa nito ay ang balat ng saging.",
    "At ang hindi nabubulok na basura ay walang kakayahang mabulok. Isa sa halimbawa nito ay ang plastik na bote.",
    "Ang balat ng saging ay halimbawa ng nabubulok na basura.",
    "Ang plastik na bote ay halimbawa ng hindi nabubulok na basura. Ito ay tumatagal ng 450 taon upang matunaw. Ang mga bote ay maaaring gamitin muli o maaaring gawing palayok ng halaman.",
    "Naku!! Ang pagkakawalang bahala mo ay nagresulta sa pagbaha na sumira sa mga bahay-bahay at mabahong amoy na nagsanhi ng pagkakasakit ng mga tao. Gusto mo ba ulit subukan?",
    "Nabubulok", "Hindi Nabubulok"};

    private bool joystickTutorialFinished = false;
    private bool attackTutorialFinished = false;
    private bool pickUpTutorialFinished = false;
    private bool isTrashBagInstantiated = false;
    private string JoystickTutorialStatus = "Not yet done";
    private PlayableDirector TimelineDirector;

    private void Awake()
    {
        TimelineDirector = timeline.GetComponent<PlayableDirector>();
        isMissionFinished = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            isMissionFinished[i] = false;
        }
    }

    private void Start()
    {
        ChangeLanguage(playerController.language);
        //make camera follow the movable character
        CameraFollower.target = PlayerCharacter.transform;
        TutorialJoystick.SetActive(true);
    }

    public void ContinueNew()
    {
        enemy[0].enemySpeed = 0.75f;
        enemy[1].enemySpeed = 0.75f;
        enemy[2].enemySpeed = 0.75f;
        if (NewTrashPanel[0].activeSelf)
        {
            NewTrashPanel[0].SetActive(false);
        }
        else
        {
            NewTrashPanel[1].SetActive(false);
        }
    }

    private void Update()
    {
        englishAudio[0].volume = playerController.fxMusicVolume;
        englishAudio[1].volume = playerController.fxMusicVolume;
        englishAudio[2].volume = playerController.fxMusicVolume;
        englishAudio[3].volume = playerController.fxMusicVolume;
        englishAudio[4].volume = playerController.fxMusicVolume;
        englishAudio[5].volume = playerController.fxMusicVolume;
        TagalogAudio[0].volume = playerController.fxMusicVolume;
        TagalogAudio[1].volume = playerController.fxMusicVolume;
        TagalogAudio[2].volume = playerController.fxMusicVolume;
        TagalogAudio[3].volume = playerController.fxMusicVolume;
        TagalogAudio[4].volume = playerController.fxMusicVolume;
        TagalogAudio[5].volume = playerController.fxMusicVolume;
        //Check every update the status of tutorial
        StartCoroutine(Tutorial());
        
        //check if playable director animation after completing the mission has finished
        if (timeline.activeSelf && TimelineDirector.time >= 94)
        {
            SegregationTutorial.SetActive(true);
        }
        
        //check if trash is not null
        if(trash != null)
        {
            //check if trash is already encountered
            if (!playerController.TrashEncountered[trash.tag])
            {
                //show panel and pause game
                switch (trash.tag)
                {
                    case "Banana Peel":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        NewTrashPanel[0].SetActive(true);
                        break;
                    case "Plastic Bottles":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        NewTrashPanel[1].SetActive(true);
                        break;
                }
                playerController.TrashEncountered[trash.tag] = true;
            }

            //check if trash is in the trash list
            if (trashTags.Contains(trash.tag))
            {
                //increment the number of collected trash then set it inactive.
                IncrementMissionReq(2);
                trash.gameObject.SetActive(false);
                SetTrash(null);
            }
        }

        //check if player collected the max number of trashes in game
        if(GetMissionReqNum(2) == 6)
        {
            SetMissionFinished(2);
        }

        //check if joystick tutorial is finished
        if(joystickTutorialFinished)
        {
            this.SetMissionFinished(0);
            JoystickTutorialStatus = "Done";
        }

        //check if attack tutorial is finished
        if(attackTutorialFinished)
        {
            SetMissionFinished(1);
        }

        //check if enemy health is 0 and
        if(enemy[0].getHealth() <= 0 && !isTrashBagInstantiated)
        {
            isTrashBagInstantiated = true;
        }

        //update UI
        missionText[0].text = "Move using the joystick: " + JoystickTutorialStatus;
        missionText[1].text = "Defeat the enemy: " + GetMissionReqNum(1) + " /3";
        missionText[2].text = "Collect the trashes: " + GetMissionReqNum(2) + " /6";
    }

    IEnumerator Tutorial()
    {
        if ((movementJoystick.joystickVec.x > .5 || movementJoystick.joystickVec.y > .5) && !joystickTutorialFinished)
        {
            joystickTutorialFinished = true;
            yield return new WaitForSeconds(.75f);
            TutorialJoystick.SetActive(false);
            TutorialAttack.SetActive(true);
        }
        
        if (!pickUpTutorialFinished && GetMissionReqNum(2) == 6)
        {
            TutorialPickup.SetActive(false);
            pickUpTutorialFinished = true;
            PlayerCharacter.SetActive(false);
            PlayerHealthBar.SetActive(false);
            timeline.SetActive(true);
            CameraFollower.target = PlayerCharacterForAnimation.transform;
            PlayerCharacterForAnimation.SetActive(true);
        }
    }
    public void isClicked()
    {
        attackTutorialFinished = true;
        TutorialAttack.SetActive(false);
        TutorialPickup.SetActive(true);
    }

    void ChangeLanguage(string language)
    {
        if (language == "filipino")
        {
            Tutorial1Text.text = Filipino_dialogues[0];
            Tutorial2Text.text = Filipino_dialogues[1];
            Tutorial3Text.text = Filipino_dialogues[2];
            LoloHarmDialogue1.text = Filipino_dialogues[3];
            LoloHarmDialogue2.text = Filipino_dialogues[4];
            LoloHarmDialogue3.text = Filipino_dialogues[5];
            LoloHarmDialogue4.text = Filipino_dialogues[6];
            LoloHarmDialogue5.text = Filipino_dialogues[7];
            NewBananaPeelDialog.text = Filipino_dialogues[8];
            NewPlasticBottleDialog.text = Filipino_dialogues[9];
            NewPlasticBottleDialog.fontSize = 13.5f;
            DeathDialog.text = Filipino_dialogues[10];
            BiodegradableText.text = Filipino_dialogues[11];
            NonBiodegradableText.text = Filipino_dialogues[12];
            englishAudio[0].mute= true;
            englishAudio[1].mute = true;
            englishAudio[2].mute = true;
            englishAudio[3].mute = true;
            englishAudio[4].mute = true;
            englishAudio[5].mute = true;
        }
        else
        {
            Tutorial1Text.text = English_dialogues[0];
            Tutorial2Text.text = English_dialogues[1];
            Tutorial3Text.text = English_dialogues[2];
            LoloHarmDialogue1.text = English_dialogues[3];
            LoloHarmDialogue2.text = English_dialogues[4];
            LoloHarmDialogue3.text = English_dialogues[5];
            LoloHarmDialogue4.text = English_dialogues[6];
            LoloHarmDialogue5.text = English_dialogues[7];
            NewBananaPeelDialog.text = English_dialogues[8];
            NewPlasticBottleDialog.text = English_dialogues[9];
            DeathDialog.text = English_dialogues[10];
            BiodegradableText.text = English_dialogues[11];
            NonBiodegradableText.text = English_dialogues[12];
            TagalogAudio[0].mute= true;
            TagalogAudio[1].mute = true;
            TagalogAudio[2].mute = true;
            TagalogAudio[3].mute = true;
            TagalogAudio[4].mute = true;
            TagalogAudio[5].mute = true;
        }   
    }
}
