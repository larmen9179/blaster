using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReceiveSmall : MonoBehaviour
{
    private manageSpawn manageSpawn;
    public ParticleSystem cheeseExplode;
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

            ParticleSystem explosion = Instantiate(cheeseExplode, transform.position, Quaternion.identity);
            explosion.Play();
            
            Destroy(gameObject);
        }
        
    }

    void OnDestroy(){
        manageSpawn.enemyDefeated();
        Debug.Log("small mouse just died");
    }

}
