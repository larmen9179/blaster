using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "playerBullet"){
            Destroy(collision.gameObject);

            enemyHealthMedium enemyHealth = GetComponent<enemyHealthMedium>();
            damageDealer damageDealer = collision.GetComponent<damageDealer>();

            enemyHealth.takeDamage(damageDealer.getDamage());
            
        }
    }
}
