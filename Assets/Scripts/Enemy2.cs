using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy2 : MonoBehaviour
{

    public float height = 2.0f;

    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

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
                FindObjectOfType<Manager_game>().IncreaseMoney();
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
                    FindObjectOfType<Manager_game>().IncreaseMoney();
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
    }

    // Update is called once per frame
    void Update()
    {
    }
}
