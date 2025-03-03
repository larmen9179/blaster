using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReceiveTank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "playerBullet"){
            tankStateSwitch t = GetComponent<tankStateSwitch>();
            if(!t.armored){
                enemyHealthDefault e = GetComponent<enemyHealthDefault>();
                damageDealer d = collision.GetComponent<damageDealer>();
                e.takeDamage(d.getDamage());
            }
        }
    }
}
