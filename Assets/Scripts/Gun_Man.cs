using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Man : MonoBehaviour
{
    public GameObject gun_man;
    Animator animator;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1.3f;
    public bool attacked = false;
    public Image nowHpbar;

    public GameObject basicbullet;
    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }
    void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;

        gun_man.transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        
        if(h > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if(h < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if(y > 0 || y < 0)
        {
            animator.SetBool("moving", true);
        }
        else animator.SetBool("moving", false);
        transform.Translate(new Vector3(h * 5,0,0) * Time.deltaTime);
        transform.Translate(new Vector3(0,y * 3,0) * Time.deltaTime);
        // if(Input.GetKey(KeyCode.RightArrow)) 
        // {
        //     transform.localScale = new Vector3(-1,1,1);
        //     animator.SetBool("moving", true);
        //     transform.Translate(Vector3.right * Time.deltaTime * 5);
        // }
        // else if(Input.GetKey(KeyCode.LeftArrow)) 
        // {
        //     transform.localScale = new Vector3(1,1,1);
        //     animator.SetBool("moving", true);
        //     transform.Translate(Vector3.left * Time.deltaTime * 5);
        // }
        // else if(Input.GetKey(KeyCode.UpArrow)) 
        // {
            
        //     animator.SetBool("moving", true);
        //     transform.Translate(Vector3.up * Time.deltaTime * 3);
        // }
        // else if(Input.GetKey(KeyCode.DownArrow)) 
        // {
            
        //     animator.SetBool("moving", true);
        //     transform.Translate(Vector3.down * Time.deltaTime * 3);
        // }
        

        // if(Input.GetKeyDown(KeyCode.K) &&
        // !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_gun"))
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_gun"))
                animator.SetTrigger("attack");
            if(transform.localScale.x == -1)
                Instantiate(basicbullet, 
                            new Vector3 (transform.position.x + 1.6f,transform.position.y + 0.4f, 0.0f),
                             Quaternion.Euler(0, 180.0f, 0));
            else
                Instantiate(basicbullet, 
                            new Vector3 (transform.position.x - 1.6f,transform.position.y + 0.4f, 0.0f), 
                            Quaternion.Euler(0, 0.0f, 0));
            
        }
    
    }

    
}
