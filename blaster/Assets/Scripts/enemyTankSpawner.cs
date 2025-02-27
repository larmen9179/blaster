using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTankSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float spawnDistance = 40f;
    private Camera mainCam;
    public GameObject tank;
    void Start()
    {
        mainCam = Camera.main;
        spawnTank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnTank(){
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

        //GameObject createdEnemy = 
        Instantiate(tank, spawnPos, Quaternion.identity);
    }
}
