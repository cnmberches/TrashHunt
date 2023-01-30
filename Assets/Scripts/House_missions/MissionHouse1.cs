using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class MissionHouse1 : Mission
{
    public TextMeshProUGUI[] missionText = new TextMeshProUGUI[3];
    public Almanac AlmanacController;
    public GameObject joyStick, attackbtn, mission, segregation;
    [SerializeField] PlayerController Player;
    [SerializeField] TMP_Text Deadtxt, bio, nonBio, Congratstxt, exitpromt, Communitytxt;
    [SerializeField] AudioSource tagalogDeath, englishDeath;

    private string[] Biodegradable = { "Banana Peel", "Rotten Banana", "Orange peel", "Box", "Crampled Paper", "Dried Leaf", "Tiolet Paper", "Paper Bag", "Rotten Food", "Rotten Carrot" };
    private string[] NonBiodegradble = { "Can", "Plastic Bottles", "Candy Wrapper", "Jar", "Plastic", "Styro Cup", "Tetra pack" };
    private bool isSegregating = false;
    string[] English_dialogues = {
    "Oh no!! Your lack of effort and knowledge resulted into flood that destroyed houses and bad smell of environment that causes sickness to people. Would you like to try again?",
    "Biodegradable", "Non-biodegradable",
    "Congratulations for finishing the level 1 of house map! This is your reward!",
    "The Community Stage is now open. You can now look for Auntie Deanna and get mission.",
    "Are you sure you want to quit? Your progress will not be saved."};

    string[] Filipino_dialogues = {
    "Naku!! Ang pagkakawalang bahala mo ay nagresulta sa pagbaha na sumira sa mga bahay-bahay at mabahong amoy na nagsanhi ng pagkakasakit ng mga tao. Gusto mo ba ulit subukan?",
    "Nabubulok", "Hindi Nabubulok",
    "Binabati kita sa pagtapos sa level 1 ng house map! Ito ang iyong reward!",
    "Ang Community Stage ay bukas na ngayon. Hanapin mo na si Auntie Deanna at kumuha ng misyon",
    "Sigurado ka ba na gusto mo mag quit? Ang iyong mga naging progress ay hindi ito masasave"};

    private void Start()
    {
        ChangeLanguage(Player.language);
    }
    private void Awake()
    {
        isMissionFinished = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            isMissionFinished[i] = false;
        }
    }
    void Update()
    {
        tagalogDeath.volume = Player.fxMusicVolume;
        englishDeath.volume = Player.fxMusicVolume;
        if (trash != null)
        {
            //check if trash is already encountered
            if (!AlmanacController.GetTrashEncountered(trash.tag))
            {
                //show panel and pause game
                switch (trash.tag)
                {
                    case "Banana Peel":
                        break;
                    case "Plastic Bottles":
                        break;
                }
                AlmanacController.UpdateTrashEncountered(trash.tag);
            }

            //check if trash is in the trash list
            //first mission
            if (Biodegradable.Contains(trash.tag))
            {
                //increment the number of collected trash then set it inactive.
                IncrementMissionReq(0);
                trash.gameObject.SetActive(false);
                SetTrash(null);
            }
            else if (NonBiodegradble.Contains(trash.tag))
            {
                IncrementMissionReq(1);
                trash.gameObject.SetActive(false);
                SetTrash(null);
            }
        }
        
        //check if player collected 3 biodegrable trashes in game
        if (GetMissionReqNum(0) == 5)
        {
            SetMissionFinished(0);
        }

        //check if player collected 3 non biodegradble trashesh
        if(GetMissionReqNum(1) == 5)
        {
            SetMissionFinished(1);
        }
        //check if player deafeted all monsters
        if(GetMissionReqNum(2) == 1)
        {
            SetMissionFinished(2);
        }
        
        missionText[0].text = "Collect 5 Biodegradble trash: " + GetMissionReqNum(0) + " /5";
        missionText[1].text = "Collect 5 Non - Biodegrable trash: " + GetMissionReqNum(1) + " /5";
        missionText[2].text = "Defeat 1 trash monsters: " + GetMissionReqNum(2) + " /1";

        if (AllMissionFinished() && !isSegregating)
        {
            joyStick.SetActive(false) ;
            attackbtn.SetActive(false) ;
            mission.SetActive(false) ;
            StartCoroutine(DelayedSegregationUI());
            isSegregating = true;
        }
    }

    IEnumerator DelayedSegregationUI()
    {
        Player.MovementFx.mute = true;
        Player.playerSpeed = 0f;
        yield return new WaitForSeconds(0.50f);
        segregation.SetActive(true);
    }

    public override void UpdateEnemyKilled()
    {
            missionReqNum[2]++;
    }
    void ChangeLanguage(string language)
    {
        if (language == "filipino")
        {
            Deadtxt.text = Filipino_dialogues[0];
            bio.text = Filipino_dialogues[1];
            nonBio.text= Filipino_dialogues[2];
            Congratstxt.text = Filipino_dialogues[3];
            Communitytxt.text = Filipino_dialogues[4];
            exitpromt.text= Filipino_dialogues[5];
            englishDeath.mute = true;
        }
        else
        {
            Deadtxt.text = English_dialogues[0];
            bio.text = English_dialogues[1];
            nonBio.text = English_dialogues[2];
            Congratstxt.text = English_dialogues[3];
            Communitytxt.text = English_dialogues[4];
            exitpromt.text = English_dialogues[5];
            tagalogDeath.mute = true;
        }
    }
}
