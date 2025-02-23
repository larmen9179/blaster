using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public GameObject minion;
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

    public void takeDamage(int damage)
    {
       currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);

            Vector2 killedPosition = (Vector2)transform.position;

            for (int i = 0; i < 3; i++)
            {
                Instantiate(minion, killedPosition, Quaternion.identity);
            }
        }
    }
}
