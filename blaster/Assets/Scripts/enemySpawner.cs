using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDistance = 2f;
    public float level = 0;
    public int enemyCount = 4;
    public float enemySpeed = 5;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        for(int i = 0;i < enemyCount + (2 * level);i++){
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;
        
        float camHeight = mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;

        //top
        if(side == 0){
            spawnPos = new Vector2(Random.Range(-camWidth, camWidth), camHeight + spawnDistance);
        }
        //bottom
        else if(side == 1){
            spawnPos = new Vector2(Random.Range(-camWidth, camWidth), -camHeight + -spawnDistance);
        }
        //left
        else if(side == 2){
            spawnPos = new Vector2(-camWidth - spawnDistance, Random.Range(-camHeight, camHeight));
        }
        //right
        else if(side == 3){
            spawnPos = new Vector2(camWidth + spawnDistance, Random.Range(-camHeight, camHeight));
        }

        GameObject createdEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = createdEnemy.GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(0f, 360f);
    
        Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        rb.velocity = moveDirection * enemySpeed;


    }

}
