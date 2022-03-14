using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sword_Man : MonoBehaviour
{ 
    public GameObject objSwordMan;
    Animator animator;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1.0f;
    public bool attacked = false;
    void AttackTrue()
    {
        attacked = true;
        Debug.Log("attack!! "+ attacked);
    }
    void AttackFalse()
    {
        attacked = false;
        Debug.Log("attack!! "+ attacked);
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
        atkDmg = 40;

        objSwordMan.transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
        SetAttackSpeed(1.0f);
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
        

        if(Input.GetKeyDown(KeyCode.K) &&
        !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }
    }

    
}
