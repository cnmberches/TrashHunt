using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[] position = new float[3];
    public float bgMusicVolume = 1;
    public float fxMusicVolume = 1;
    public bool isTutorialFinished = false;
    public string language = null;
    public IDictionary<string, int> CollectedTrash = new Dictionary<string, int>();
    public IDictionary<string, int> CraftedItems = new Dictionary<string, int>();
    public IDictionary<string, bool> TrashEncountered = new Dictionary<string, bool>();
    public IDictionary<int, bool> HouseLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> CommunityLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> SchoolLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> ParkLevelFinished = new Dictionary<int, bool>();
    public IDictionary<string, bool> StageFinished = new Dictionary<string, bool>();
    public IDictionary<int, int> HouseStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> CommunityStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> SchoolStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> ParkStarsGained = new Dictionary<int, int>();
    public IDictionary<string, bool> AchievementList = new Dictionary<string, bool>();
    public IDictionary<string, bool> QuizTracker = new Dictionary<string, bool>();

    public SaveData()
    {
        IDictionary<string, int> CollectedTrash = new Dictionary<string, int>();
        IDictionary<string, int> CraftedItems = new Dictionary<string, int>();
        IDictionary<string, bool> TrashEncountered = new Dictionary<string, bool>();
        IDictionary<int, bool> HouseLevelFinished = new Dictionary<int, bool>();
        IDictionary<int, bool> CommunityLevelFinished = new Dictionary<int, bool>();
        IDictionary<int, bool> SchoolLevelFinished = new Dictionary<int, bool>();
        IDictionary<int, bool> ParkLevelFinished = new Dictionary<int, bool>();
        IDictionary<string, bool> StageFinished = new Dictionary<string, bool>();
        IDictionary<int, int> HouseStarsGained = new Dictionary<int, int>();
        IDictionary<int, int> CommunityStarsGained = new Dictionary<int, int>();
        IDictionary<int, int> SchoolStarsGained = new Dictionary<int, int>();
        IDictionary<int, int> ParkStarsGained = new Dictionary<int, int>();
        IDictionary<string, bool> AchievementList = new Dictionary<string, bool>();
        IDictionary<string, bool> QuizTracker = new Dictionary<string, bool>();
        //For Creating inital saved data
        CollectedTrash.Add("Banana Peel", 0);
        CollectedTrash.Add("Plastic Bottles", 0);
        CollectedTrash.Add("Box", 0);
        CollectedTrash.Add("Can", 0);
        CollectedTrash.Add("Candy Wrapper", 0);
        CollectedTrash.Add("Crumpled Paper", 0);
        CollectedTrash.Add("Dried Leaf", 0);
        CollectedTrash.Add("Jar", 0);
        CollectedTrash.Add("Orange Peel", 0);
        CollectedTrash.Add("Paper Bag", 0);
        CollectedTrash.Add("Plastic", 0);
        CollectedTrash.Add("Rotten Banana", 0);
        CollectedTrash.Add("Styro Cup", 0);
        CollectedTrash.Add("Tetra pack", 0);
        CollectedTrash.Add("Tiolet Paper", 0);
        CollectedTrash.Add("Rotten Carrot", 0);
        CollectedTrash.Add("Rotten Food", 0);

        TrashEncountered.Add("Banana Peel", false);
        TrashEncountered.Add("Plastic Bottles", false);
        TrashEncountered.Add("Box", false);
        TrashEncountered.Add("Can", false);
        TrashEncountered.Add("Candy Wrapper", false);
        TrashEncountered.Add("Crumpled Paper", false);
        TrashEncountered.Add("Dried Leaf", false);
        TrashEncountered.Add("Jar", false);
        TrashEncountered.Add("Orange peel", false);
        TrashEncountered.Add("Paper Bag", false);
        TrashEncountered.Add("Plastic", false);
        TrashEncountered.Add("Rotten Banana", false);
        TrashEncountered.Add("Styro Cup", false);
        TrashEncountered.Add("Tetra pack", false);
        TrashEncountered.Add("Tiolet Paper", false);
        TrashEncountered.Add("Rotten Carrot", false);
        TrashEncountered.Add("Rotten Food", false);
        TrashEncountered.Add("Tire", false);

        CraftedItems.Add("Pencil Holder", 0);
        CraftedItems.Add("Plastic Bottle Pot", 0);
        CraftedItems.Add("Book Organizer", 0);

        HouseLevelFinished.Add(1, false);
        HouseLevelFinished.Add(2, false);
        HouseLevelFinished.Add(3, false);
        CommunityLevelFinished.Add(1, false);
        CommunityLevelFinished.Add(2, false);
        CommunityLevelFinished.Add(3, false);
        ParkLevelFinished.Add(1, false);
        ParkLevelFinished.Add(2, false);
        ParkLevelFinished.Add(3, false);
        SchoolLevelFinished.Add(1, false);
        SchoolLevelFinished.Add(2, false);
        SchoolLevelFinished.Add(3, false);

        StageFinished.Add("House", false);
        StageFinished.Add("Community", false);
        StageFinished.Add("School", false);
        StageFinished.Add("Park", false);

        HouseStarsGained.Add(1, 0);
        HouseStarsGained.Add(2, 0);
        HouseStarsGained.Add(3, 0);
        CommunityStarsGained.Add(1, 0);
        CommunityStarsGained.Add(2, 0);
        CommunityStarsGained.Add(3, 0);
        SchoolStarsGained.Add(1, 0);
        SchoolStarsGained.Add(2, 0);
        SchoolStarsGained.Add(3, 0);
        ParkStarsGained.Add(1, 0);
        ParkStarsGained.Add(2, 0);
        ParkStarsGained.Add(3, 0);

        AchievementList.Add("Newbie Crafter", false);
        AchievementList.Add("Community is Opened", false);
        AchievementList.Add("School is opened", false);
        AchievementList.Add("Park is Opened", false);
        AchievementList.Add("King of Crafter", false);

        QuizTracker.Add("isQuizIsPassed", false);
        QuizTracker.Add("isQuizIsFailed", false);

        float []position = new float[3];
        position[0] = 0.5189999f;
        position[1] = 1.439f;
        position[2] = 0f;
        bool isTutorialFinished = false;
        float bgMusicVolume = 1;
        float fxMusicVolume = 1;

        this.TrashEncountered = TrashEncountered;
        this.CollectedTrash = CollectedTrash;
        this.HouseStarsGained = HouseStarsGained;
        this.CommunityStarsGained = CommunityStarsGained;
        this.ParkStarsGained = ParkStarsGained;
        this.SchoolStarsGained = SchoolStarsGained;
        this.position = position;
        this.bgMusicVolume = bgMusicVolume;
        this.fxMusicVolume = fxMusicVolume;
        this.isTutorialFinished = isTutorialFinished;
        this.StageFinished = StageFinished;
        this.HouseLevelFinished = HouseLevelFinished;
        this.CommunityLevelFinished = CommunityLevelFinished;
        this.ParkLevelFinished = ParkLevelFinished;
        this.SchoolLevelFinished = SchoolLevelFinished;
        this.CraftedItems = CraftedItems;
        this.AchievementList = AchievementList;
        this.QuizTracker = QuizTracker;
    }

    public SaveData(PlayerController player, bool isOnBase)
    {
        TrashEncountered = player.TrashEncountered;
        CollectedTrash = player.CollectedTrash;
        HouseStarsGained = player.HouseStarsGained;
        CommunityStarsGained = player.CommunityStarsGained;
        ParkStarsGained = player.ParkStarsGained;
        SchoolStarsGained = player.SchoolStarsGained;

        bgMusicVolume = player.bgMusicVolume;
        fxMusicVolume = player.fxMusicVolume;

        isTutorialFinished = player.isTutorialFinished;
        StageFinished = player.StageFinished;
        HouseLevelFinished = player.HouseLevelFinished;
        CommunityLevelFinished = player.CommunityLevelFinished;
        ParkLevelFinished = player.ParkLevelFinished;
        SchoolLevelFinished = player.SchoolLevelFinished;
        CraftedItems = player.CraftedItems;
        AchievementList = player.AchievementList;
        QuizTracker = player.QuizTracker;
        if (isOnBase)
        {
            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
        this.language = player.language;
    }

    public SaveData(SaveData prevData, float bgMusicVolume, float fxMusicVolume)
    {
        this.bgMusicVolume = bgMusicVolume;
        this.fxMusicVolume = fxMusicVolume;
        TrashEncountered = prevData.TrashEncountered;
        CollectedTrash = prevData.CollectedTrash;
        HouseStarsGained = prevData.HouseStarsGained;
        CommunityStarsGained = prevData.CommunityStarsGained;
        ParkStarsGained = prevData.ParkStarsGained;
        SchoolStarsGained = prevData.SchoolStarsGained;

        bgMusicVolume = prevData.bgMusicVolume;
        fxMusicVolume = prevData.fxMusicVolume;

        isTutorialFinished = prevData.isTutorialFinished;
        StageFinished = prevData.StageFinished;
        HouseLevelFinished = prevData.HouseLevelFinished;
        CommunityLevelFinished = prevData.CommunityLevelFinished;
        ParkLevelFinished = prevData.ParkLevelFinished;
        SchoolLevelFinished = prevData.SchoolLevelFinished;
        position = prevData.position;
        CraftedItems = prevData.CraftedItems;
        AchievementList= prevData.AchievementList;
        QuizTracker= prevData.QuizTracker;
        language = prevData.language;
    }
}
