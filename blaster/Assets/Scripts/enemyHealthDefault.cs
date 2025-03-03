using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthDefault : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
