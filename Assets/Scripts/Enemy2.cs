using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy2 : MonoBehaviour
{

    public float height = 2.0f;

    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;
    public float moveSpeed = 1.0f;
    
    private Transform target;
    float attackDelay;

    
    Animator enemyAnimator;

    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, int _atkSpeed)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }

    public Gun_Man gun_man;
    public Sword_Man sword_man;
    Image nowHpbar;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("bullet"))
        {
            nowHp -= gun_man.atkDmg;
            Debug.Log(nowHp);
            if(nowHp <= 0)
            {
                FindObjectOfType<gamemanager>().IncreaseMoney();
                // 스크립트 이름으로 찾아서 해당 스크립트 내 함수 실행시킴
                // 타 스크립트 변수에 접근할 때 용이할 듯
                Destroy(gameObject);
            }
        }
        if (col.CompareTag("sword"))
        {
            if(sword_man.attacked)
            {
                nowHp -= sword_man.atkDmg;
                Debug.Log(nowHp);
                if(nowHp <= 0)
                {
                    FindObjectOfType<gamemanager>().IncreaseMoney();
                    // 스크립트 이름으로 찾아서 해당 스크립트 내 함수 실행시킴
                    // 타 스크립트 변수에 접근할 때 용이할 듯
                    Destroy(gameObject);
                }
            }
        }
    }



    void Start()
    {
        
        SetEnemyStatus("Enemy2", 100, 10, 1);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //enemyAnimator = enemy.enemyAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance <= 10)
        {
            FaceTarget();
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        float dirX = target.position.x - transform.position.x;
        float dirY = target.position.y - transform.position.y;

        dirX = (dirX < 0) ? -1 : 1;
        dirY = (dirY < 0) ? -1 : 1;

        transform.Translate(new Vector2(dirX, dirY) * moveSpeed * Time.deltaTime);
        
    }

    void FaceTarget()
    {
        if(target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
