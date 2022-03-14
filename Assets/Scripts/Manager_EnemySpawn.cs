using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Manager_EnemySpawn : MonoBehaviour
{
    public bool enableSpawn = true;
 
 
    // 카메라 크기
    float camera_minx;
    float camera_maxx;
    float camera_miny;
    float camera_maxy;
 
    // 동시 적 스폰 갯수
    int enemyCount = 0;
    // 최대 적 스폰 갯수
    int enemySpawnLimit = 10;
 
 
    // 생성된 객체를 받아올 배열
    public GameObject[] enemies;
 
    void SpawnEnemy()
    {
        //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomX = Random.Range(camera_minx, camera_maxx); 
        float randomY = Random.Range(camera_miny, camera_maxy - 5.0f);
        if (enableSpawn)
        {
            // Prefub의 태그를 이용해서 적 갯수 찾아오기
            //enemies = GameObject.FindGameObjectsWithTag("enemy_wizard");
            if(enemies.Length < 5)
            {
                //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
                GameObject enemy = (GameObject)Instantiate(enemies[0], new Vector3(randomX, randomY, 0f), Quaternion.identity);               
                enemyCount++;
            }
 
        }
        if(enemyCount == enemySpawnLimit)
            enableSpawn = false;
    }
    void Start()
    {
        // 카메라 크기 받아오기
        var height = 2 * Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;
        camera_maxy = 0.5f * height;
        camera_miny = -camera_maxy;
        camera_maxx = 0.5f * width;
        camera_minx = -camera_maxx;

        Debug.Log("카메라 위치 y value: " + camera_maxy+ " %" + camera_miny);
        // 적 스폰 관련 값 초기화
        
 
 
        //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        
        InvokeRepeating("SpawnEnemy", 3, 1);
            
    }
    void Update()
    {
 
    }
}
