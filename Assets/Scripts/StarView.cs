using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StarView : MonoBehaviour
{
    public PlayerController player;
    public TMP_Text stars;
    public IDictionary<int, int> HouseStarsGained = new Dictionary<int, int>();
    int starGained = 0;
    bool HouseStarsAll3;
    public TMP_Text starH1, starH2, starH3, starC1, starC2, starC3, starS1, starS2, starS3, starP1, starP2, starP3;
    void Start()
    {
        starGained += player.HouseStarsGained[1];
        starGained += player.HouseStarsGained[2];
        starGained += player.HouseStarsGained[3];
        starGained += player.CommunityStarsGained[1];
        starGained += player.CommunityStarsGained[2];
        starGained += player.CommunityStarsGained[3];
        starGained += player.SchoolStarsGained[1];
        starGained += player.SchoolStarsGained[2];
        starGained += player.SchoolStarsGained[3];
        starGained += player.ParkStarsGained[1];
        starGained += player.ParkStarsGained[2];
        starGained += player.ParkStarsGained[3];
    }

    // Update is called once per frame
    void Update()
    {
       
        HouseStarsAll3 = player.HouseStarsGained[1] == 3 && player.HouseStarsGained[2] == 3 && player.HouseStarsGained[3] == 3;
        stars.text = starGained.ToString()+" /36";

        starH1.text = player.HouseStarsGained[1].ToString();
        starH2.text = player.HouseStarsGained[2].ToString();
        starH3.text = player.HouseStarsGained[3].ToString();

        starC1.text = player.CommunityStarsGained[1].ToString();
        starC2.text = player.CommunityStarsGained[2].ToString();
        starC3.text = player.CommunityStarsGained[3].ToString();

        starS1.text = player.SchoolStarsGained[1].ToString();
        starS2.text = player.SchoolStarsGained[2].ToString();
        starS3.text = player.SchoolStarsGained[3].ToString();

        starP1.text = player.ParkStarsGained[1].ToString();
        starP2.text = player.ParkStarsGained[2].ToString();
        starP3.text = player.ParkStarsGained[3].ToString();
        
    }
  
   
   
}
