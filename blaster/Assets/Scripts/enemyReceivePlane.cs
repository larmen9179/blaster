using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReceivePlane : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "playerBullet"){

            updateHits(collision);

            enemyHealthDefault planeHealth = GetComponent<enemyHealthDefault>();
            
            damageDealer damageDealer = collision.GetComponent<damageDealer>();

            planeHealth.takeDamage(damageDealer.getDamage());
        }
    }

    void OnDestroy(){
        manageSpawn.enemyDefeated();
        Debug.Log(GameObject.FindWithTag("GameController").GetComponent<manageSpawn>().getEnemiesAlive());
        Debug.Log("plane just died");
    }

    private void updateHits(Collider2D collision){
        //checking is piercing shots is allowed
            if(GameObject.FindWithTag("Player").GetComponent<playerUpgradePrefs>().pierceShot){
                if(collision.GetComponent<damageDealer>().getHits() > 0){
                    collision.GetComponent<damageDealer>().setHits(collision.GetComponent<damageDealer>().getHits() - 1);
                }
                else{
                    Destroy(collision.gameObject);
                }
            }
            else{ //if not, then just destroy the shot
                Destroy(collision.gameObject);
            }
    }
}
