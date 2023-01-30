using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Park2Mission : Mission
{
    public TextMeshProUGUI[] missionText = new TextMeshProUGUI[3];
    public Almanac AlmanacController;
    public GameObject joyStick, attackbtn, mission, segregation;
    public GameObject[] NewTrashPanel;
    public EnemyController[] enemy;
    [SerializeField] PlayerController Player;
    [SerializeField] TMP_Text Deadtxt, bio, nonBio, Congratstxt, exitpromt, jar, Pizzabox, Styrocup;
    [SerializeField] AudioSource tagalogDeath, englishDeath;
    private string[] Biodegradable = { "Banana Peel", "Rotten Banana", "Orange peel", "Box", "Crampled Paper", "Dried Leaf", "Tiolet Paper", "Paper Bag", "Rotten Food", "Rotten Carrot" };
    private string[] NonBiodegradble = { "Can", "Plastic Bottles", "Candy Wrapper", "Jar", "Plastic", "Styro Cup", "Tetra pack" };
    private bool isSegregating = false;

    string[] English_dialogues = {
    "Oh no!! Your lack of effort and knowledge resulted into flood that destroyed houses and bad smell of environment that causes sickness to people. Would you like to try again?",
    "Biodegradable", "Non-biodegradable",
    "Congratulations for finishing the level 2 of park map! This is your reward!",
    "Are you sure you want to quit? Your progress will not be saved.",
    "Bottle jar is an example of non-biodegradable trash. It is made of a glass, and it takes 1 million years for a glass bottle to decompose.",
    "Pizza box is an example of biodegradable waste. It takes as long as 90 days to decompose. It also can be put on a recycle bin.",
    "Styro cup is an example of non-biodegradable trash. Styrofoam cups breaks into tiny pieces and stay in the environment for hundreds of years."};


    string[] Filipino_dialogues = {
    "Naku!! Ang pagkakawalang bahala mo ay nagresulta sa pagbaha na sumira sa mga bahay-bahay at mabahong amoy na nagsanhi ng pagkakasakit ng mga tao. Gusto mo ba ulit subukan?",
    "Nabubulok", "Hindi Nabubulok",
    "Binabati kita sa pagtapos sa level 2 ng park map! Ito ang iyong reward!",
     "Sigurado ka ba na gusto mo mag quit? Ang iyong mga naging progress ay hindi ito masasave",
    "Ang bote ng garapon ay halimbawa ng hindi nabubulok na basura. Ito ay gawa sa isang salamin, at tumatagal ng 1 milyong taon para mabulok ang isang bote ng salamin.",
    "Ang kahon ng pizza ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 90 araw upang mabulok. Maaari rin itong ilagay sa isang recycle bin.",
    "Ang styro cup ay halimbawa ng hindi nabubulok na basura. Ang mga baso na Styrofoam ay nahahati sa maliliit na piraso at nananatili sa kapaligiran sa loob ng daan-daang taon."};

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
        enemy[7].enemySpeed = 0.75f;
        enemy[8].enemySpeed = 0.75f;
        enemy[9].enemySpeed = 0.75f;
        enemy[10].enemySpeed = 0.75f;
        enemy[11].enemySpeed = 0.75f;
        enemy[12].enemySpeed = 0.75f;
        if (NewTrashPanel[0].activeSelf)
        {
            NewTrashPanel[0].SetActive(false);
        }
        else if (NewTrashPanel[1].activeSelf)
        {
            NewTrashPanel[1].SetActive(false);
        }
        else
        {
            NewTrashPanel[2].SetActive(false);
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
                    case "Jar":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        enemy[3].enemySpeed = 0;
                        enemy[4].enemySpeed = 0;
                        enemy[5].enemySpeed = 0;
                        enemy[6].enemySpeed = 0;
                        enemy[7].enemySpeed = 0;
                        enemy[8].enemySpeed = 0;
                        enemy[9].enemySpeed = 0;
                        enemy[10].enemySpeed = 0;
                        enemy[11].enemySpeed = 0;
                        enemy[12].enemySpeed = 0;
                            NewTrashPanel[0].SetActive(true);
                        
                        break;
                    case "Box":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        enemy[3].enemySpeed = 0;
                        enemy[4].enemySpeed = 0;
                        enemy[5].enemySpeed = 0;
                        enemy[6].enemySpeed = 0;
                        enemy[7].enemySpeed = 0;
                        enemy[8].enemySpeed = 0;
                        enemy[9].enemySpeed = 0;
                        enemy[10].enemySpeed = 0;
                        enemy[11].enemySpeed = 0;
                        enemy[12].enemySpeed = 0;
                            NewTrashPanel[1].SetActive(true);
                        break;
                    case "Styro Cup":
                        enemy[0].enemySpeed = 0;
                        enemy[1].enemySpeed = 0;
                        enemy[2].enemySpeed = 0;
                        enemy[3].enemySpeed = 0;
                        enemy[4].enemySpeed = 0;
                        enemy[5].enemySpeed = 0;
                        enemy[6].enemySpeed = 0;
                        enemy[7].enemySpeed = 0;
                        enemy[8].enemySpeed = 0;
                        enemy[9].enemySpeed = 0;
                        enemy[10].enemySpeed = 0;
                        enemy[11].enemySpeed = 0;
                        enemy[12].enemySpeed = 0;
                            NewTrashPanel[2].SetActive(true);
                      
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
        if (GetMissionReqNum(0) == 13)
        {
            SetMissionFinished(0);
        }

        //check if player collected all non biodegradble trashesh
        if (GetMissionReqNum(1) == 13)
        {
            SetMissionFinished(1);
        }
        //check if player deafeted all monsters
        if (GetMissionReqNum(2) == 13)
        {
            SetMissionFinished(2);
        }

        missionText[0].text = "Collect 13 Biodegradble trash: " + GetMissionReqNum(0) + " /13";
        missionText[1].text = "Collect 13 Non - Biodegrable trash: " + GetMissionReqNum(1) + " /13";
        missionText[2].text = "Defeat 13 trash monsters: " + GetMissionReqNum(2) + " /13";

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
            exitpromt.text = Filipino_dialogues[4];
            exitpromt.fontSize = 11;
            jar.text = Filipino_dialogues[5];
            Pizzabox.text = Filipino_dialogues[6];
            Styrocup.text = Filipino_dialogues[7];
            englishDeath.mute = true;
        }
        else
        {
            Deadtxt.text = English_dialogues[0];
            bio.text = English_dialogues[1];
            nonBio.text = English_dialogues[2];
            Congratstxt.text = English_dialogues[3];
            exitpromt.text = English_dialogues[4];
            jar.text = English_dialogues[5];
            Pizzabox.text = English_dialogues[6];
            Styrocup.text = English_dialogues[7];
            tagalogDeath.mute = true;
        }
    }
}