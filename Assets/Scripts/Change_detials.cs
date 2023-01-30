using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Change_detials : MonoBehaviour
{
    public TextMeshProUGUI TrashName;
    public TextMeshProUGUI Content;
    public Image trashIcon;
    public GameObject DetailsPanel;
    public Sprite newSprite;
    public Button button;
    [SerializeField] PlayerController player;
    [SerializeField] GameSettings settings;


    string[] English_dialogues = {"Banana peel is an example of biodegradable waste. It takes as long as 2 years to decompose. It can also be used as fertilizers for the plants.",
    "Pizza box is an example of biodegradable waste. It takes as long as 90 days to decompose. It also can be put on a recycle bin.",
    "Can is an example of non–biodegradable trash. It takes a 100 to 500 years to dissolve.",
    "Plastic bottle is an example of non–biodegradable trash. It takes a 450 years to dissolve. Bottles can be reused or can be turned into a plant pot.",
    "Styro cup is an example of non-biodegradable trash. Styrofoam cups breaks into tiny pieces and stay in the environment for hundreds of years.",
    "Crumpled paper is an example of biodegradable waste. It takes 2 to 6 weeks to decompose. Recycling of paper reduce greenhouse gas emissions.",
    "Plastic bag is an example of non–biodegradable trash. It takes about 1,000 years to decompose. It can be reused as a plastic wraps.",
    "Bottle jar is an example of non-biodegradable trash. It is made of a glass, and it takes 1 million years for a glass bottle to decompose.",
    "Tissue paper is an example of biodegradable waste. It takes as long as 3 years to decompose if it is wet, and 1 month if it is dry.",
    "Rotten carrot is an example of biodegradable. It decomposes after a few weeks.",
    "Candy wrapper is an example of non-biodegradable trash. It takes from 10 to 20 years to dissolve.",
    "Dried leaf is an example of biodegradable trash. It takes as long as 6 to 12 months. When decomposed, dried leaves add nutrients to the soil.",
    "Juice tetra pack is an example of non-biodegradable trash. It takes 300 years to decompose.",
    "Rotten meat is an example of biodegradable waste. It takes 1 month to more than a year for the meat to fully decompose.",
    "Orange peel is an example of biodegradable waste. It takes as long as 2 years to decompose. It can also be used as pest repellent for the plants.",
    "Rotten banana is an example of biodegradable trash. It takes 3 to 4 weeks to fully decompose. It adds nutrition to soils.",
    "Worn tire is an example of non-biodegradable trash. It takes 50 to 80 years or longer, for a tire to decompose.",
    "Paper bag is an example of biodegradable waste. It takes about a month to decompose. It can also be reused as a bag for small trashes.",
    "Continue"};

    string[] Filipino_dialogues = { "Ang balat ng saging ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng 2 taon bago ito tuluyang mabulok. Ginagamit rin itong pampataba ng mga halaman.",
    "Ang kahon ng pizza ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 90 araw upang mabulok. Maaari rin itong ilagay sa isang recycle bin.",
    "Ang lata ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 100 to 500 taon bago ito matunaw.",
    "Ang plastik na bote ay halimbawa ng hindi nabubulok na basura. Ito ay tumatagal ng 450 taon upang matunaw. Ang mga bote ay maaaring gamitin muli o maaaring gawing palayok ng halaman.",
    "Ang styro cup ay halimbawa ng hindi nabubulok na basura. Ang mga baso na Styrofoam ay nahahati sa maliliit na piraso at nananatili sa kapaligiran sa loob ng daan-daang taon.",
    "Ang lukot na papel ay halimbawa ng nabubulok na basura. Inaabot ito ng 2 hanggang 6 na linggo bago ito mabulok. Ang pag-recycle ng papel ay nakakabawas ng mga greenhouse gas emissions.",
    "Ang plastik bag ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 1,000 years bago ito matunaw. Maaari itong magamit muli bilang isang plastic wrap.",
    "Ang bote ng garapon ay halimbawa ng hindi nabubulok na basura. Ito ay gawa sa isang salamin, at tumatagal ng 1 milyong taon para mabulok ang isang bote ng salamin.",
    "Ang tisyu ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 3 taon upang mabulok kung ito ay basa, at 1 buwan kung ito ay tuyo.",
    "Ang bulok na karot ay halimbawa ng nabubulok na basura. Nabubulok ito pagkatapos ng ilang linggo.",
    "Ang balat ng kendi ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 10 hanggang 20 years bago ito matunaw.",
    "Ang tuyong dahon ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 6 hanggang 12 buwan. Kapag nabubulok, ang mga tuyong dahon ay nagdaragdag ng mga sustansya sa lupa.",
    "Ang juice tetra pack ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 300 na taon bago ito matunaw.",
    "Ang bulok na karne ay halimbawa ng nabubulok na basura. Inaabot ito ng 1 o hanggang kahalating taon bago ito tuluyang mabulok.",
    "Ang balat ng orange ay halimbawa ng nabubulok na basura. Inaabot ito ng 2 taon bago ito tuluyang mabulok. Ito ay maaaring gamitin bilang pangkontra sa mga insekto para sa mga halaman.",
    "Ang bulok na saging ay halimbawa ng nabubulok na basura. Ito ay inaabot ng 3 hanggag 4 na linggo bago ito mabulok. Ginagamit rin itong pataba sa lupa.",
    "Ang sirang gulong ay halimbawa ng hindi nabubulok na basura. Ito ay tumatagal ng 50 hanggang 80 taon o mas matagal pa, bago mabulok ang isang gulong.",
    "Ang paper bag ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng halos 1 buwan upang mabulok. Maaari rin itong magamit muli bilang isang bag para sa maliliit na basura.",
    "Continue"};

    private void Update()
    {
        if (settings.ChangeInLanguage)
        {
            settings.ChangeInLanguage = false;
        }
    }

    public void Banana()
    {
        if(player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Banana Peel";
                Content.text = Filipino_dialogues[0];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Banana Peel";
                Content.text = English_dialogues[0];
            }
        }
    }

    public void PizzaB()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Pizza Box";
                Content.text = Filipino_dialogues[1];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Pizza Box";
                Content.text = English_dialogues[1];
            }
        }
       

    }
    public void TinCan()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Can";
                Content.text = Filipino_dialogues[2];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Can";
                Content.text = English_dialogues[2];
            }
        }
    }
    public void PlasticBottle()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Plastic Bottle";
                Content.text = Filipino_dialogues[3];
                Content.fontSize = 9;
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Plastic Bottle";
                Content.text = English_dialogues[3];
            }
        }
           
    }
    public void StyroCup()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Styro Cup";
                Content.text = Filipino_dialogues[4];
            }
        }
        else{
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Styro Cup";
                Content.text = English_dialogues[4];
            }
        }
    }
    public void CrumpledPaper()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Crumpled Paper";
                Content.text = Filipino_dialogues[5];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Crumpled Paper";
                Content.text = English_dialogues[5];
            }
        }
    }
    public void Plastic()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Plastic Bag";
                Content.text = Filipino_dialogues[6];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Plastic Bag";
                Content.text = English_dialogues[6];
            }
        }
    }
    public void jar()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Bottle Jar";
                Content.text = Filipino_dialogues[7];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Bottle Jar";
                Content.text = English_dialogues[7];
            }
        }
    }
    public void ToiletPaper()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Tissue Paper";
                Content.text = Filipino_dialogues[8];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Tissue Paper";
                Content.text = English_dialogues[8];
            }
        }
    }
    public void rottenCarrot()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Carrot";
                Content.text = Filipino_dialogues[9];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Carrot";
                Content.text = English_dialogues[9];
            }
        }
    }
    public void candyWrap()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Candy Wrapper";
                Content.text = Filipino_dialogues[10];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Candy Wrapper";
                Content.text = English_dialogues[10];
            }
        }
    }
    public void DriedLeaf()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Dried Leaf";
                Content.text = Filipino_dialogues[11];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Dried Leaf";
                Content.text = English_dialogues[11];
            }
        }
    }
    public void TetraPack()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Juice Tetra Pack";
                Content.text = Filipino_dialogues[12];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Juice Tetra Pack";
                Content.text = English_dialogues[12];
            }
        }
    }
    public void RottenMeat()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Meat";
                Content.text = Filipino_dialogues[13];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Meat";
                Content.text = English_dialogues[13];
            }
        }
    }
    public void OrangPeel()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Orange Peel";
                Content.text = Filipino_dialogues[14];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Orange Peel";
                Content.text = English_dialogues[14];
            }
        }
    }
    public void RottenBanana()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Banana";
                Content.text = Filipino_dialogues[15];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Rotten Banana";
                Content.text = English_dialogues[15];
            }
        }
    }
    public void WornTire()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Worn Tire";
                Content.text = Filipino_dialogues[16];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Worn Tire";
                Content.text = English_dialogues[16];
            }
        }
    }
    public void PaperBag()
    {
        if (player.language == "filipino")
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Paper Bag";
                Content.text = Filipino_dialogues[17];
            }
        }
        else
        {
            if (button.interactable == true)
            {
                DetailsPanel.gameObject.SetActive(true);
                trashIcon.sprite = newSprite;
                TrashName.text = "Paper Bag";
                Content.text = English_dialogues[17];
            }
        }
    }
}
