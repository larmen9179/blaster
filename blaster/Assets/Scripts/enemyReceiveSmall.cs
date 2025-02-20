using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReceiveSmall : MonoBehaviour
{
    public ParticleSystem cheeseExplode;
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

            ParticleSystem explosion = Instantiate(cheeseExplode, transform.position, Quaternion.identity);
            explosion.Play();
            
            Destroy(gameObject);
        }
        
    }
}
