using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Arrow : MonoBehaviour
{
    //public GameObject HitEffect;
    public Rigidbody2D rb;
    public int damage = 30;
    public float speed = 30;
    public GameObject impactEffect;
    private float ArrowTravelDistance = 3f;
    private Vector3 initPos, targetPos;
    private bool TargetIsOnLeft = false;
    private bool enemyPresent = false;

    private void Start()
    {
        initPos = transform.position;
        if(TargetIsOnLeft)
        {
            transform.Rotate(0f,180f, 0);
            TargetIsOnLeft= false;
        }
    }

    private void Update()
    {
        
        Vector3 moveDir = (targetPos - transform.position).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        var distance = Vector3.Distance(initPos, transform.position);
       
        if (distance >= ArrowTravelDistance)
        {
           
            Destroy(gameObject);
        }

        if (!enemyPresent)
        {
            Destroy(gameObject);
        }
    }

    public void SetTargetPostion(Vector3 TargetPos, float arrowSpeed, bool TargetIsOnLeft, bool enemyPresent)
    {
        targetPos = TargetPos;
        speed = arrowSpeed;
        this.TargetIsOnLeft = TargetIsOnLeft;
       this.enemyPresent = enemyPresent;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }

        if (hitInfo.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}