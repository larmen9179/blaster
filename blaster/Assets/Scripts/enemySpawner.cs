using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;
        
        //top
        if(side == 0){

        }
        //bottom
        else if(side == 1){

        }
        //left
        else if(side == 2){

        }
        //right
        else if(side == 3){

        }
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0));
        spawnPosition.z = 0;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}
