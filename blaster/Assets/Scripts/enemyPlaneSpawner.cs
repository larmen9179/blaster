using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlaneSpawner : MonoBehaviour
{
    public float spawnChance;
    public GameObject enemyPlane;
    private Camera mainCam;
    private float spawnDistance = 2f;
    //private float padding = 5;
    // Start is called before the first frame update
    void Start()
    {

        mainCam = Camera.main;
        //change this later
        //as of right now this code will spawn a ship no matter what for testing
        float randomChance = Random.Range(spawnChance, spawnChance);
        //if(randomChance <= spawnChance){
            spawnPlane();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnPlane(){

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
        Instantiate(enemyPlane, spawnPos, Quaternion.identity);
    }
}
