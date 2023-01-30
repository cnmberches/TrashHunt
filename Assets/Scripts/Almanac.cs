using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almanac : MonoBehaviour
{
    public IDictionary<string, bool> TrashEncountered;


    private void Awake()
    {
        TrashEncountered= new Dictionary<string, bool>();
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
        TrashEncountered.Add("Styro Cup", false);
        TrashEncountered.Add("Tetra pack", false);
        TrashEncountered.Add("Tiolet Paper", false);
        TrashEncountered.Add("Rotten Banana", false);
        TrashEncountered.Add("Rotten Food", false);
        TrashEncountered.Add("Rotten Carrot", false);
        TrashEncountered.Add("Tire", false);
    }
   
    public void UpdateTrashEncountered(string tag)
    {
        TrashEncountered[tag] = true;
    }

    public bool GetTrashEncountered(string tag)
    {
        return TrashEncountered[tag];
    }
}
