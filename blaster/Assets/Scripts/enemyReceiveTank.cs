using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReceiveTank : MonoBehaviour
{
    private manageSpawn manageSpawn;
    // Start is called before the first frame update
    void Start()
    {
        manageSpawn = FindObjectOfType<manageSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "playerBullet"){

            updateHits(collision);

            tankStateSwitch t = GetComponent<tankStateSwitch>();
            if(!t.armored){
                enemyHealthDefault e = GetComponent<enemyHealthDefault>();
                damageDealer d = collision.GetComponent<damageDealer>();
                e.takeDamage(d.getDamage());
            }
        }
    }
    
    void OnDestroy(){
        manageSpawn.enemyDefeated();
        Debug.Log(GameObject.FindWithTag("GameController").GetComponent<manageSpawn>().getEnemiesAlive());
        Debug.Log("tank just died");
    }

    private void updateHits(Collider2D collision){
        //checking is piercing shots is allowed
            if(GameObject.FindWithTag("Player").GetComponent<playerUpgradePrefs>().pierceShot){
                //if we have at least 1 hit left, don't destroy the shot and update the hits
                if(collision.GetComponent<damageDealer>().getHits() > 0){
                    collision.GetComponent<damageDealer>().setHits(collision.GetComponent<damageDealer>().getHits() - 1);
                }
                else{// if we're out of hits, remove the object
                    Destroy(collision.gameObject);
                }
            }
            else{ //if pierceShots isn't true, then just destroy the shot
                Destroy(collision.gameObject);
            }
    }
}
