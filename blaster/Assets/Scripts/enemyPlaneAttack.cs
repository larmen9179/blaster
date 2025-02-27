using System.Collections;
using UnityEngine;

public class enemyPlaneAttack : MonoBehaviour
{
    public float initialSpeed = 3f;  // Base movement speed
    public float speedIncreaseRate = 0.5f;  // How much speed increases per second
    public float explosionRadius = 1.5f;  // Damage area when exploding
    public int damageAmount = 25;  // Damage dealt to player on impact
    public GameObject explosionEffect; // Optional explosion particle effect

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private float currentSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (player == null) return; // If player is missing, stop movement

        // Move towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

        // Increase speed over time to make it more aggressive
        currentSpeed += speedIncreaseRate * Time.deltaTime;

        // Flash red if close to the player
        if (Vector2.Distance(transform.position, player.position) < 1f)
        {
            spriteRenderer.color = Color.red; // Warning effect
        }

        // Check if the bomber reaches the player
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Create explosion effect if assigned
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Apply damage in a radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hit in colliders)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }
            }
        }

        Debug.Log("Kamikaze Bomber Exploded!");
        Destroy(gameObject); // Destroy enemy on explosion
    }

    // Draw the explosion radius in the Unity editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
