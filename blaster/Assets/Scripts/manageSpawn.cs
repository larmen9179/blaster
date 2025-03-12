using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class manageSpawn : MonoBehaviour
{
    public GameObject enemyMouse;
    public GameObject enemyPlane;
    public GameObject enemyTank;
    private Camera mainCam;
    private float mouseSpawnDistance = 2f;
    private float planeSpawnDistance = 2f;
    private float tankSpawnDistance = 40f;
    private int enemiesAlive;
    public float level;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        startRound();
        
    }

    public void enemyDefeated(){
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            StartCoroutine(EndRound());
        }
    }

    IEnumerator EndRound()
    {
        Debug.Log("new round starting");
        yield return new WaitForSeconds(5f); // Small delay before next round
        //ShowUpgrades(); // Show upgrade selection screen

        //yield return new WaitUntil(() => upgradeChosen); // Wait for player to choose an upgrade
        
        //roundNumber++;
        //enemiesToSpawn += 2; // Increase enemy count for difficulty
        startRound();
    }
    
    private void startRound(){
        enemiesAlive = 0;

        for(int i = 0;i < 4;i++){
            spawn("mouse");
            enemiesAlive += 3;
        }

        spawn("plane");
        enemiesAlive++;
        spawn("tank");
        enemiesAlive++;
    }

    private void spawn(String enemyType){

        GameObject g = null;
        float distance = 0;

        if(enemyType == "mouse"){
            g = enemyMouse;
            distance = mouseSpawnDistance;
        }
        else if(enemyType == "plane"){
            g = enemyPlane;
            distance = planeSpawnDistance;
        }
        else if(enemyType == "tank"){
            g = enemyTank;
            distance = tankSpawnDistance;
        }

        int side = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;
        
        float camHeight = mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;

        //top
        if(side == 0){
            spawnPos = new Vector2(Random.Range(-camWidth, camWidth), camHeight + distance);
        }
        //bottom
        else if(side == 1){
            spawnPos = new Vector2(Random.Range(-camWidth, camWidth), -camHeight + -distance);
        }
        //left
        else if(side == 2){
            spawnPos = new Vector2(-camWidth - distance, Random.Range(-camHeight, camHeight));
        }
        //right
        else if(side == 3){
            spawnPos = new Vector2(camWidth + distance, Random.Range(-camHeight, camHeight));
        }


        //GameObject createdEnemy = 
        Instantiate(g, spawnPos, Quaternion.identity);
    }
}
