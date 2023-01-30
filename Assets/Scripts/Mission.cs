using System.Linq;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public bool[] isMissionFinished;

    public bool isFinished = false;
    public GameObject trash;
    public int[] missionReqNum;
    public string[] trashTags = { "Banana Peel", "Plastic Bottles", "Box", "Can", "Candy Wrapper", "Crampled Paper", "Dried Leaf", "Jar", "Orange peel", "Paper Bag", "Plastic", "Rotten Banana", "Styro Cup", "Tetra pack", "Tiolet Paper", "Rotten Carrot", "Rotten Food", "Pizza Box" , "Tire" };

    public void SetMissionFinished(int index)
    {
        isMissionFinished[index] = true;
    }

    public bool GetMissionStatus(int index)
    {
        return isMissionFinished[index];
    }

    public void IncrementMissionReq(int index)
    {
        missionReqNum[index]++;
    }

    public int GetMissionReqNum(int index)
    {
        return missionReqNum[index];
    }

    public bool AllMissionFinished()
    {
        if (!isMissionFinished.Contains(false))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetTrash(GameObject trash)
    {
        this.trash = trash;
    }   
    
    public GameObject getTrash()
    {
        return trash;
    }

    public virtual void UpdateEnemyKilled()
    {
        missionReqNum[1]++;
    }
}
