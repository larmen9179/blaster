using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Player's max health
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took damage! Current health: " + currentHealth);
    }

}
