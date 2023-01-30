using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Mission3Community : Mission
{
    public TextMeshProUGUI[] missionText = new TextMeshProUGUI[3];
    public Almanac AlmanacController;
    public GameObject joyStick, attackbtn, mission, segregation, newPanel;
    public EnemyController[] enemy;
    [SerializeField] PlayerController Player;
    [SerializeField] TMP_Text Deadtxt, bio, nonBio, Congratstxt, exitpromt, School, RottenMeat;
    [SerializeField] AudioSource tagalogDeath, englishDeath;

    private string[] Biodegradable = { "Banana Peel", "Rotten Banana", "Orange peel", "Box", "Crampled Paper", "Dried Leaf", "Tiolet Paper", "Paper Bag", "Rotten Food", "Rotten Carrot" };
    private string[] NonBiodegradble = { "Can", "Plastic Bottles", "Candy Wrapper", "Jar", "Plastic", "Styro Cup", "Tetra pack" };
    private bool isSegregating = false;

    string[] English_dialogues = {
    "Oh no!! Your lack of effort and knowledge resulted into flood that destroyed houses and bad smell of environment that causes sickness to people. Would you like to try again?",
    "Biodegradable", "Non-biodegradable",
    "Congratulations for finishing the level 3 of community map! This is your reward!",
     "The school stage is now open. You can now look for Uncle Larry and get missions.",
      "Are you sure you want to quit? Your progress will not be saved.",
    "Rotten meat is an example of biodegradable waste. It takes 1 month to more than a year for the meat to fully decompose."};

    string[] Filipino_dialogues = {
    "Naku!! Ang pagkakawalang bahala mo ay nagresulta sa pagbaha na sumira sa mga bahay-bahay at mabahong amoy na nagsanhi ng pagkakasakit ng mga tao. Gusto mo ba ulit subukan?",
    "Nabubulok", "Hindi Nabubulok",
    "Binabati kita sa pagtapos sa level 3 ng community map! Ito ang iyong reward!",
     "Ang school Stage ay bukas na ngayon. Hanapin mo na si Uncle Larry at kumuha ng misyon",
      "Sigurado ka ba na gusto mo mag quit? Ang iyong mga naging progress ay hindi ito masasave",
    "Ang bulok na karne ay halimbawa ng nabubulok na basura. Inaabot ito ng 1 o hanggang kahalating taon bago ito tuluyang mabulok."};

    private void Awake()
    {
        isMissionFinished = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            isMissionFinished[i] = false;
        }
    }
    private void Start()
    {
        ChangeLanguage(Player.language);
    }

    public void ContinueNew()
    {
        enemy[0].enemySpeed = 0.75f;
        enemy[1].enemySpeed = 0.75f;
        enemy[2].enemySpeed = 0.75f;
        enemy[3].enemySpeed = 0.75f;
        enemy[4].enemySpeed = 0.75f;
        enemy[5].enemySpeed = 0.75f;
        enemy[6].enemySpeed = 0.75f;
        if (newPanel.activeSelf)
        {
            newPanel.SetActive(false);
        }
    }

    void Update()
    {
        tagalogDeath.volume = Player.fxMusicVolume;
        englishDeath.volume = Player.fxMusicVolume;
        if (trash != null)
        {
            //check if trash is already encountered
            if (!AlmanacController.GetTrashEncountered(trash.tag) && Player.TrashEncountered[trash.tag] == false)
            {
                //show panel and pause game
                switch (trash.tag)
                {
                    case "Rotten Food":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        enemy[3].enemySpeed = 0;
                        enemy[4].enemySpeed = 0;
                        enemy[5].enemySpeed = 0;
                        enemy[6].enemySpeed = 0;
                            newPanel.SetActive(true);
                        break;
                }
                AlmanacController.UpdateTrashEncountered(trash.tag);
                Player.TrashEncountered[trash.tag] = true;
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

        //check if player collected all biodegrable trashes in game
        if (GetMissionReqNum(0) == 15)
        {
            SetMissionFinished(0);
        }

        //check if player collected all non biodegradble trashesh
        if (GetMissionReqNum(1) == 15)
        {
            SetMissionFinished(1);
        }
        //check if player deafeted all monsters
        if (GetMissionReqNum(2) == 7)
        {
            SetMissionFinished(2);
        }

        missionText[0].text = "Collect 15 Biodegradble trash: " + GetMissionReqNum(0) + " /15";
        missionText[1].text = "Collect 15 Non - Biodegrable trash: " + GetMissionReqNum(1) + " /15";
        missionText[2].text = "Defeat 7 trash monsters: " + GetMissionReqNum(2) + " /7";

        if (AllMissionFinished() && !isSegregating)
        {
            joyStick.SetActive(false);
            attackbtn.SetActive(false);
            mission.SetActive(false);
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
            nonBio.text = Filipino_dialogues[2];
            Congratstxt.text = Filipino_dialogues[3];
            School.text = Filipino_dialogues[4];
            exitpromt.text = Filipino_dialogues[5];
            RottenMeat.text = Filipino_dialogues[6];
            englishDeath.mute = true;
        }
        else
        {
            Deadtxt.text = English_dialogues[0];
            bio.text = English_dialogues[1];
            nonBio.text = English_dialogues[2];
            Congratstxt.text = English_dialogues[3];
            School.text = English_dialogues[4];
            exitpromt.text = English_dialogues[5];
            RottenMeat.text = English_dialogues[6];
            tagalogDeath.mute = true;
        }
    }
}
