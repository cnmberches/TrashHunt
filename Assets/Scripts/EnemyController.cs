using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;
    private bool isFacingRight = true;
    private int enemyMaxHealth = 100;
    private int enemyCurrentHealth = 100;
    private bool isNotSeen = true;
    private float cooldown = 1;

    public Mission mission;
    public GameObject Player;
    public float enemySpeed;
    public HealthBar healthBarController;
    public float minimumDistance;
    public float visionDistance;
    public GameObject trashPrefab;
    public LayerMask solidObjectsLayer;
    public int Damage = 10;

   public AudioSource SlimeMovementFx;
    public AudioSource SlimeAttackFx;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        healthBarController.setMaxHealth(enemyMaxHealth);
    }

    void Update()
    {
        if (Player != null)
        {
            if (gameObject.activeInHierarchy)
            {
                movement();
            }
        }
    }

    private void movement()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < visionDistance && isNotSeen)
        {
            isNotSeen = false;
        }

        if (Vector2.Distance(transform.position, Player.transform.position) > minimumDistance && !isNotSeen)
        {
            var prevPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemySpeed * Time.deltaTime);
            var targetPos = transform.position;
            var input = transform.position;
            input.x += 0.1f;
            input.y += 0.1f;
            if (isWalkable(input))
            {
                isMoving = true;
                StartCoroutine(Move(targetPos));
            }
            else
            {
                transform.position = prevPos;
            }
        }
        else if(Vector2.Distance(transform.position, Player.transform.position) <= minimumDistance)
        {
            animator.SetBool("isMoving", false);
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            else if(cooldown <=0)
            {
                cooldown = 1f;
                animator.ResetTrigger("IsAttacking");
                StartCoroutine(Attack(Player.gameObject));
            }
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.5f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    IEnumerator Attack(GameObject Player)
    {
        if(Player != null && Player.GetComponent<PlayerController>().getHealth() > 0)
        {
            animator.SetTrigger("IsAttacking");
            PlayerController player = Player.GetComponent<PlayerController>();
            if (player != null)
            {
                player.takeDamage(Damage);
            }
        }
        if(!SlimeAttackFx.isPlaying && Player.GetComponent<PlayerController>().getHealth() > 0)
        {
            SlimeAttackFx.Play();
        }
        yield return new WaitForSeconds(.9f);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        animator.SetBool("isMoving", isMoving);
        if(!SlimeMovementFx.isPlaying)
        {
            SlimeMovementFx.Play();
        }
        if (!isMoving)
        {
            //stop animation of walking to left
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

        if ((targetPos.x - Player.transform.position.x) > 0 && isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
        }
        else if (((targetPos.x - Player.transform.position.x) < 0) && !isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
        }
        yield return null;
    }
    public void takeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        healthBarController.setHealth(enemyCurrentHealth);
        if(enemyCurrentHealth <= 0)
        {
            Die();
            healthBarController.canvas.enabled = false;
        }
    }

    public int getHealth()
    {
        return enemyCurrentHealth;
    }

    void Die()
    {
        Instantiate(trashPrefab, transform.position, transform.rotation);
        mission.UpdateEnemyKilled();
        Destroy(gameObject);
    }
}
