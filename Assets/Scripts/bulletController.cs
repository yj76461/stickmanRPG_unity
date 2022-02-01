using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private float speed = 20.0f; // 이동 속도
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("enemy_wizard"))
        {    
            Destroy(gameObject);

        }
    }
    void Start() {

    }
    void Update()
    {
        transform.Translate(- speed * Time.deltaTime, 0 , 0);
        //총알이 왼쪽을 바라보고 있기에 정방향으로 맞추려고 - 붙임
    }
}