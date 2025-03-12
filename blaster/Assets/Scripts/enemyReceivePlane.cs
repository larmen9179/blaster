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
            Destroy(collision.gameObject);
            enemyHealthDefault planeHealth = GetComponent<enemyHealthDefault>();
            
            damageDealer damageDealer = collision.GetComponent<damageDealer>();

            planeHealth.takeDamage(damageDealer.getDamage());
        }
    }

    void OnDestroy(){
        manageSpawn.enemyDefeated();
        Debug.Log("plane just died");
    }
}
