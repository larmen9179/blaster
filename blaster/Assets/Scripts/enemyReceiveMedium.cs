using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public GameObject minion;
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
        if(collision.tag == "Bullet"){
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Vector2 killedPosition = (Vector2)transform.position;

            for(int i = 0;i < 3;i++){
                Instantiate(minion, killedPosition, Quaternion.identity);
            }
            
        }
    }
}
