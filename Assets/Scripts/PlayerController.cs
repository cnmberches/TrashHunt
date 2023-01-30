using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bgMusicVolume = 1;
    public float fxMusicVolume = 1;
    public string language = "english";
    public IDictionary<string, bool> TrashEncountered = new Dictionary<string, bool>();
    public IDictionary<string, int> CollectedTrash = new Dictionary<string, int>();
    public IDictionary<string, bool> StageFinished = new Dictionary<string, bool>();
    public IDictionary<int, bool> HouseLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> CommunityLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> SchoolLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, bool> ParkLevelFinished = new Dictionary<int, bool>();
    public IDictionary<int, int> HouseStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> CommunityStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> SchoolStarsGained = new Dictionary<int, int>();
    public IDictionary<int, int> ParkStarsGained = new Dictionary<int, int>();
    public IDictionary<string, int> CraftedItems = new Dictionary<string, int>();
    public IDictionary<string, bool> AchievementList = new Dictionary<string, bool>();
    public IDictionary<string, bool> QuizTracker = new Dictionary<string, bool>();

    public JoystickController movementJoystick;
    public SegregationController SegregationControllerClass;
    public Weapon weaponController;
    public HealthBar healthBar;
    public Almanac AlmanacController;
    public Mission missions;
    public AudioSource MovementFx, AttackFx;
    public GameObject JoystickUI;
    public GameObject AttackButtonUI;
    public GameObject arrowPrefab;
    public GameObject PlayerDeath;
    public GameObject ObjectCollided;
    public float arrowSpeed = 20f;
    public float playerSpeed;
    public string[] missionsList;
    public LayerMask solidObjectsLayer;
    public bool isOnBase = false;
    public bool isOnQuiz = false;
    public bool isTutorialFinished = false;

    [SerializeField] TMP_Text AuntieDeanna, UncleLarry, UncleWayne, NewbieAchievementDetails, CommunityAchievementDetails, SchoolAchievementDetails, ParkAchievementDetails, KingAchievementDetails, exitpromt, Book, pencil, pot, Communitytxt, Schooltxt, Parktxt;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameSettings settings;

    private int playerMaxHealth = 100;
    private int playerCurrentHealth = 100;
    private bool targetIsOnLeft = false;
    private bool isMoving = false;
    private bool isFacingRight = true;
    private bool enemyPresent = false;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 firePointPosition;
    private Vector3 TargetPos;

    public string[] trashTags = { "Banana Peel", "Plastic Bottles", "Box", "Can", "Candy Wrapper", "Crumpled Paper", "Dried Leaf", "Jar", "Orange peel", "Paper Bag", "Plastic", "Rotten Banana", "Styro Cup", "Tetra pack", "Tiolet Paper", "Rotten Carrot", "Rotten Food", "Pizza Box", "Tire" };

    string[] English_dialogues = {"This community stage is locked. To unlock this stage, you need to get 3 stars on all the levels of house stage and craft a pen holder.",
    "This school stage is locked. To unlock this stage, you need to get 3 stars on all the levels of community stage and craft a plastic bottle pot.",
     "This park stage is locked. To unlock this stage, you need to get 3 stars on all the levels of school stage and craft a book organizer.",
    "Craft one item in crafting box",
    "Unlock the community stage by getting 3 stars in all level of House stage and craft Pencil holder.",
    "Unlock the School stage  by getting 3 stars in all level of Community stage and craft plastic bottle pot.",
    "Unlock the Park stage  by getting 3 stars in all level of School stage and craft a book organizer.",
    "Craft all the items in crafting box.",
    "Are you sure you want to quit? Your progress will not be saved.",
    "Congratulations! You crafted a Book Organizer!",
    "Congratulations! You crafted a Pencil Holder!",
    "Congratulations! You crafted a Plastic Bottle Pot!",
    "The community stage is now open. You can now look for Auntie Deanna and get missions.",
    "The school stage is now open. You can now look for Uncle Larry and get missions.",
    "The park stage is now open. You can now look for Uncle Wayne and get missions."};

    string[] Filipino_dialogues = {"Naka-lock ang community stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa house stage at gumawa ng pen holder.",
    "Naka-lock ang school stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa community stage at gumawa ng plastic bottle pot.",
    "Naka-lock ang park stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa school stage at gumawa ng book organizer.",
        "Mag craft ng isang item mula sa crafting box",
    "Buksan ang Community stage sa pamamagitan ng pag 3 stars sa lahat ng level ng House stage at mag craft ng Pencil holder",
    "Buksan ang School stage sa pamamagitan ng pag 3 stars sa lahat ng level ng Community stage at mag craft ng plastic bottle pot",
    "Buksan ang Park stage sa pamamagitan ng pag 3 stars sa lahat ng level ng School stage at mag craft ng book organizer",
    "I-craft ang lahat ng item sa crafting box",
    "Sigurado ka ba na gusto mo mag quit? Ang iyong mga naging progress ay hindi ito masasave",
    "Binabati kita! Na craft mo na ang Book Organizer!",
    "Binabati kita! Na craft mo na ang Pencil Holder!",
    "Binabati kita! Na craft mo na ang Plastic Bottle Pot!",
    "Ang Community Stage ay bukas na ngayon. Hanapin mo na si Auntie Deanna at kumuha ng misyon",
    "Ang school Stage ay bukas na ngayon. Hanapin mo na si Uncle Larry at kumuha ng misyon",
    "Ang park Stage ay bukas na ngayon. Hanapin mo na si Uncle Wayne at kumuha ng misyon"};

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        LoadPlayer();
    }
    private void OnDestroy()
    {
        if (isOnBase)
        {
            SavePlayer();
        }
    }

    private void Start()
    {
        if (!isOnBase)
        {
            playerCurrentHealth = playerMaxHealth;
            healthBar.setMaxHealth(playerMaxHealth);
        }
        else
        {
            ChangeLanguage(language);
            LoadPlayer();
        }
    }

    void Update()
    {
        movement();
        if (!isOnBase)
        {
            attack();
            weaponController.isFiringArrow = false;
        }
        else
        {
            if (settings.ChangeInLanguage)
            {
                ChangeLanguage(language);
                settings.ChangeInLanguage = false;
            }
        }
    }

    private void attack()
    {
        if (!isOnBase)
        {
            if (weaponController.isFiringArrow && enemyPresent)
            {
                StartCoroutine(fireArrow());
            }
        }
    }

    IEnumerator fireArrow()
    {
        animator.ResetTrigger("isFiringArrow");
        animator.SetTrigger("isFiringArrow");
        yield return new WaitForSeconds(0.25f);
        if (!AttackFx.isPlaying)
        {
            AttackFx.Play();
        }
        firePointPosition = firePoint.transform.position;
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrowController = arrow.GetComponent<Arrow>();
        arrowController.SetTargetPostion(TargetPos, arrowSpeed, targetIsOnLeft,enemyPresent);
        targetIsOnLeft = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectEnemy(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyPresent = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectEnemy(collision);
    }

    void DetectEnemy(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            GameObject object1 = collision.gameObject;
            Vector3 objectPos = object1.transform.position;
            if (TargetPos == null)
            {
                TargetPos = objectPos;
            }
            else
            {
                if (Vector3.Distance(transform.position, objectPos) < Vector3.Distance(transform.position, TargetPos))
                {
                    TargetPos = objectPos;
                }
            }
            var targetRef = (transform.position - objectPos) * (-1);
           

            var firePoint_x = targetRef.x / 2;
            var firePoint_y = targetRef.y / 2;
            /**
             * The following codes are for the position of firepoint.
             * First, firepoint is determine in between of the target and the player.
             * The limit position of firepoint is at 0.6
             * The position of the firepoint should not be less than 0.45
             * */
            if (firePoint_x > 0.6)
            {
                firePoint_x = 0.6f;
            }
            else if (firePoint_x < -0.6)
            {
                firePoint_x = -0.6f;
                targetIsOnLeft = true;
            }

            if (firePoint_y > 0.6)
            {
                firePoint_y = 0.6f;
            }
            else if (firePoint_y < -0.6)
            {
                firePoint_y = -0.6f;
            }

            if (firePoint_x < 0.45 && targetRef.x > 0)
            {
                firePoint_x = .45f;
            }
            else if (firePoint_x < -0.45 && targetRef.x < 0)
            {
                firePoint_x = -0.45f;
                targetIsOnLeft = true;
            }

            if (firePoint_y < 0.45 && targetRef.y > 0)
            {
                firePoint_y = .45f;
            }
            else if (firePoint_y < -0.45 && targetRef.y < 0)
            {
                firePoint_y = -0.45f;
            }

            firePoint.transform.position = new Vector3(firePoint_x, firePoint_y, 0) + transform.position;
            float angle = Vector3.Angle(transform.position, objectPos);

            /**
             * The following code is for the angle of firepoint.
             * This is to make sure that the arrow points to the target.
             **/

            if (targetRef.x < 0.36 && targetRef.x > -0.36)
            {
                angle = 90;
            }

            if (targetRef.y < 0)
            {
                angle *= -1;
            }

            if (targetIsOnLeft)
            {
                angle *= -1;
            }
            firePoint.transform.eulerAngles = new Vector3(0, 0, angle);
            enemyPresent = true;
        }
    }
    private void movement()
    {
        if (!isMoving)
        {
            Vector2 input;
            input.x = movementJoystick.joystickVec.x;
            input.y = movementJoystick.joystickVec.y;

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                {
                    firePointPosition = firePoint.transform.position;
                    animator.ResetTrigger("isFiringArrow");
                    StartCoroutine(Move(targetPos));
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        //start movement
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);

            if (movementJoystick.joystickVec.x < 0 || movementJoystick.joystickVec.x > 0)
            {
                //start animation of walking to left
                animator.SetBool("isMoving", true);

                if (!MovementFx.isPlaying)
                {
                    MovementFx.Play();
                }
            }
            else if (movementJoystick.joystickVec.x == 0 && movementJoystick.joystickVec.y == 0)
            {
                //stop animation of walking to left
                animator.SetBool("isMoving", false);
                isMoving = false;
            }


            if (movementJoystick.joystickVec.x < 0 && isFacingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                firePoint.transform.position = firePointPosition;
                isFacingRight = false;
            }
            else if (movementJoystick.joystickVec.x > 0 && !isFacingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                firePoint.transform.position = firePointPosition;
                isFacingRight = true;
            }
            yield return null;
        }
    }

    public void takeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        healthBar.setHealth(playerCurrentHealth);
        if (playerCurrentHealth <= 0)
        {
            healthBar.gameObject.SetActive(false);
            Die();
        }
    }

    public int getHealth()
    {
        return playerCurrentHealth;
    }

    void Die()
    {
        StartCoroutine(DeathAnimation());
        JoystickUI.SetActive(false);
        AttackButtonUI.SetActive(false);
        PauseButton.SetActive(false);
    }

    IEnumerator DeathAnimation()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isDead", false);
        yield return new WaitForSeconds(4f);
        PlayerDeath.SetActive(true);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (trashTags.Contains(tag))
        {
            ObjectCollided = collision.gameObject;
            SegregationControllerClass.trashList.Add(collision.gameObject);
            missions.SetTrash(collision.gameObject);
        }
        else if (tag.Equals("CraftingTable") || tag.Equals("LoloHarm") || tag.Equals("UncleWayne")
            || tag.Equals("UncleLarry") || tag.Equals("AuntieDeanna"))
        {
            ObjectCollided = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObjectCollided = null;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, isOnBase);
    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();

        if (isOnBase)
        {
            if (isTutorialFinished)
            {
                Vector3 position;
                position.x = data.position[0];
                position.y = data.position[1];
                position.z = data.position[2];
                transform.position = position;
            }
        }

        isTutorialFinished = data.isTutorialFinished;
        CraftedItems = data.CraftedItems;
        TrashEncountered = data.TrashEncountered;
        CollectedTrash = data.CollectedTrash;
        StageFinished = data.StageFinished;
        HouseLevelFinished = data.HouseLevelFinished;
        CommunityLevelFinished = data.CommunityLevelFinished;
        ParkLevelFinished = data.ParkLevelFinished;
        SchoolLevelFinished = data.SchoolLevelFinished;
        HouseStarsGained = data.HouseStarsGained;
        CommunityStarsGained = data.CommunityStarsGained;
        ParkStarsGained = data.ParkStarsGained;
        SchoolStarsGained = data.SchoolStarsGained;
        AchievementList = data.AchievementList;
        QuizTracker = data.QuizTracker;

        bgMusicVolume = data.bgMusicVolume;
        fxMusicVolume = data.fxMusicVolume;
        language = data.language;
    }

    void ChangeLanguage(string language)
    {
        if(!isOnQuiz)
        {
            if (language == "filipino")
            {
                AuntieDeanna.text = Filipino_dialogues[0];
                AuntieDeanna.fontSize = 12;
                UncleLarry.text = Filipino_dialogues[1];
                UncleLarry.fontSize = 12;
                UncleWayne.text = Filipino_dialogues[2];
                UncleWayne.fontSize = 12;
                NewbieAchievementDetails.text = Filipino_dialogues[3];
                CommunityAchievementDetails.text = Filipino_dialogues[4];
                SchoolAchievementDetails.text = Filipino_dialogues[5];
                ParkAchievementDetails.text = Filipino_dialogues[6];
                KingAchievementDetails.text = Filipino_dialogues[7];
                exitpromt.text = Filipino_dialogues[8];
                exitpromt.fontSize = 11;
                Book.text = Filipino_dialogues[9];
                pencil.text = Filipino_dialogues[10];
                pot.text = Filipino_dialogues[11];
                Communitytxt.text = Filipino_dialogues[12];
                Schooltxt.text = Filipino_dialogues[13];
                Parktxt.text = Filipino_dialogues[14];

            }
            else
            {
                AuntieDeanna.text = English_dialogues[0];
                UncleLarry.text = English_dialogues[1];
                UncleWayne.text = English_dialogues[2];
                NewbieAchievementDetails.text = English_dialogues[3];
                CommunityAchievementDetails.text = English_dialogues[4];
                SchoolAchievementDetails.text = English_dialogues[5];
                ParkAchievementDetails.text = English_dialogues[6];
                KingAchievementDetails.text = English_dialogues[7];
                exitpromt.text = English_dialogues[8];
                Book.text = English_dialogues[9];
                pencil.text = English_dialogues[10];
                pot.text = English_dialogues[11];
                Communitytxt.text = English_dialogues[12];
                Schooltxt.text = English_dialogues[13];
                Parktxt.text = English_dialogues[14];

            }
        }
    }
}
