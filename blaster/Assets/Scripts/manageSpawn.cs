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
    private int roundNumber = 0;
    public int baseCount;

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
        roundNumber++;
        startRound();
    }
    
    private void startRound(){
        enemiesAlive = 0;

        //add 1 to base count every 4 rounds

        for(int i = 0;i < baseCount + (roundNumber % 4);i++){
            spawn("mouse");
        }

        //spawns special enemies on round presets
        //EXCEPT when the round is round 0 -> first round
        if(roundNumber > 0)
        {   
            //tank every 4 rounds and base count update
            if (roundNumber % 4 == 0)
            {
                baseCount++;
                spawn("tank");
            }

            //plane every 3 rounds
            if (roundNumber % 3 == 0)
            {
                spawn("plane");
            }

            //plane and tank every 5 rounds
            if (roundNumber % 5 == 0)
            {
                spawn("plane");
                spawn("tank");

            }

            //small chance for spawning extra enemy of special type
            int extraSpecial = Random.Range(1, 6);
            if (extraSpecial == 1)
            {
                int specialChance = Random.Range(1, 3);
                //plane tree
                if (specialChance == 1)
                {
                    spawn("plane");
                }
                else //tank tree
                {
                    spawn("tank");
                }
            }
        }

        if (baseCount > 8)
        {
            baseCount = 8;
        }
    }

    private void spawn(String enemyType){

        GameObject g = null;
        float distance = 0;

        if(enemyType == "mouse"){
            g = enemyMouse;
            distance = mouseSpawnDistance;
            enemiesAlive += 3;
        }
        else if(enemyType == "plane"){
            g = enemyPlane;
            distance = planeSpawnDistance;
            enemiesAlive++;
        }
        else if(enemyType == "tank"){
            g = enemyTank;
            distance = tankSpawnDistance;
            enemiesAlive++;
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
